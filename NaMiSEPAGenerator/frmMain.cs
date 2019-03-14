using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Threading;
using System.Threading.Tasks;

using NaMiLib;
using Perrich.SepaWriter;
using System.IO;

namespace NaMiSEPAGenerator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        List<NaMiMitglied> GetAktiveMitglieder(Connector con, int GruppierungsID)
        {
            return con.GetFullList(con.GetFilteredList(NaMiFilters.status, GruppierungsID, "Aktiv"), GruppierungsID);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            int GruppierungsID = 0; //<-------------------------------------WICHTIG!!
            List<NaMiMitglied> skipped = new List<NaMiMitglied>();
            Connector con = new Connector();
            SaveFileDialog sfd = new SaveFileDialog();
            try
            {
                if (!isVaildInput())
                {
                    MessageBox.Show("Die angegebenen Daten sind unvollständig oder Falsch!", "Unvollständige oder Falsche Daten!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sfd.Filter = "XML-Dateien|*.xml";
                if (sfd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                login.ShowDialog();
                if (login.Password.Equals("") || login.Mitgliedsnummer.Equals(""))
                {
                    MessageBox.Show("Es wurde keine Datei erstellt!", "Keine Eingaben ermittelt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!con.Login(login.Mitgliedsnummer, login.Password))
                {
                    MessageBox.Show("Falscher Benutzername oder Falsches Kennwort!", "Fehler bei der Anmeldung", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pbFortschritt.Visible = true;
                pbFortschritt.MarqueeAnimationSpeed = 25;

                GruppierungsID = con.GetRootGruppierung().id;

                Task<List<NaMiMitglied>> task = Task<List<NaMiMitglied>>.Factory.StartNew(() => GetAktiveMitglieder(con, GruppierungsID));

                while (task.Status != TaskStatus.RanToCompletion)
                {
                    Application.DoEvents();
                }

                Dictionary<string, int> mPIban = GetMitgliederPerIBAN(task.Result);

                SepaDebitTransfer transfer = new SepaDebitTransfer();

                SepaIbanData creditor = new SepaIbanData();
                creditor.Bic = txtBIC.Text;
                creditor.Iban = txtIBAN.Text;
                creditor.Name = NormalizeString(txtName.Text);

                transfer.Creditor = creditor;
                transfer.RequestedExecutionDate = dTExecutionDate.Value;
                transfer.PersonId = txtGlaeubigerID.Text;
                transfer.MessageIdentification = creditor.Bic + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
                transfer.InitiatingPartyName = creditor.Name;
                if (!creditor.IsValid)
                {
                    MessageBox.Show("Fehler ihre Bankdaten scheinen Ungültig zu sein!", "Fehler in den Bankdaten!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                List<string> transactions = new List<string>();
                transactions.Add("Debtor;IBAN;Mandatsreferenz;Verwendungszweck;Betrag");
                foreach (NaMiMitglied m in task.Result)
                {
                    if (!(m.kontoverbindung.iban == null || m.kontoverbindung.bic == null || m.kontoverbindung.kontoinhaber == null))
                        if (!(m.kontoverbindung.iban.Equals("") || m.kontoverbindung.bic.Equals("") || m.kontoverbindung.kontoinhaber.Equals("")))
                        {
                            SepaDebitTransferTransaction transaction = new SepaDebitTransferTransaction();
                            SepaIbanData debtor = new SepaIbanData();
                            debtor.Name = m.kontoverbindung.kontoinhaber.ToString();
                            debtor.Iban = m.kontoverbindung.iban.ToString();
                            debtor.Bic = m.kontoverbindung.bic.ToString();
                            if (!debtor.IsValid)
                                skipped.Add(m);
                            else
                            {
                                transaction.Debtor = debtor;
                                transaction.MandateIdentification = NormalizeString(m.kontoverbindung.mitgliedsNummer.ToString() + m.vorname + m.nachname).Replace(" ", "");
                                transaction.RemittanceInformation = "DPSG Beitrag fuer " + NormalizeString(m.vorname) + " " + NormalizeString(m.nachname);
                                transaction.Amount = GetAmount(mPIban[transaction.Debtor.Iban], m);
                                transfer.AddDebitTransfer(transaction);
                                transactions.Add(String.Format("{0};{1};{2};{3};{4}", transaction.Debtor.Name, transaction.Debtor.Iban, transaction.MandateIdentification, transaction.RemittanceInformation, transaction.Amount.ToString()));
                            }
                        }
                        else
                            skipped.Add(m);
                }
                using (StreamWriter sw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), new System.Text.UTF8Encoding(false)))
                {
                    sw.Write(transfer.AsXmlString());
                }
                using (StreamWriter sw = new StreamWriter(new FileStream(sfd.FileName + ".Transactions.csv", FileMode.Create), new System.Text.UTF8Encoding(false)))
                {
                    foreach (string line in transactions)
                    {
                        sw.WriteLine(line);
                    }
                }
                if (skipped.Count > 0)
                {
                    CreateErrorReport(skipped, sfd.FileName + ".ErrorReport.txt");
                    MessageBox.Show("Es wurde erfolgreich eine SEPA-Datei erstellt! Dabei wurden jedoch " + skipped.Count.ToString() + " Datensätze übersprungen!\r\nEine Reportdatei wurde unter folgenden Pfad erstellt:\r\n" + sfd.FileName + ".ErrorReport.txt", "Erfolgreich mit Warnungen!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Es wurde erfolgreich eine SEPA-Datei erstellt!", "Erfolgreich!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (NaMiNotLoggedInException ex)
            {
                MessageBox.Show("Fehler:\r\n" + ex.Message, "Fehler: Nicht Eingeloggt!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NaMiException<List<NaMiObjekt>> ex)
            {
                MessageBox.Show("Fehler:\r\n" + ex.Message, "Fehler im NaMiRequest!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NaMiException<NaMiMitglied> ex)
            {
                MessageBox.Show("Fehler:\r\n" + ex.Message, "Fehler im NaMiRequest!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler:\r\n" + ex.Message, "Unbekannter Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Logout();
                pbFortschritt.Visible = false;
                pbFortschritt.MarqueeAnimationSpeed = 0;
            }
        }

        private Dictionary<string, int> GetMitgliederPerIBAN(List<NaMiMitglied> mitglieder)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (NaMiMitglied m in mitglieder)
            {
                if (m.kontoverbindung.iban != null)
                    if (result.ContainsKey(m.kontoverbindung.iban.ToString()))
                    {
                        result[m.kontoverbindung.iban.ToString()] = result[m.kontoverbindung.iban.ToString()] + 1;
                    }
                    else
                    {
                        result.Add(m.kontoverbindung.iban.ToString(), 1);
                    }
            }
            return result;
        }
        private decimal GetAmount(int anzMitglieder, NaMiMitglied mitglied)
        {
            if (anzMitglieder > 2)
                return decimal.Parse(txtBeitrag3.Text);
            else if (anzMitglieder > 1)
                return decimal.Parse(txtBeitrag2.Text);
            else if (mitglied.beitragsartId[0] == 2)
                return decimal.Parse(txtBeitrag2.Text);
            else
                return decimal.Parse(txtBeitrag1.Text);
        }

        private bool isVaildInput()
        {
            decimal dec;
            bool rv = true;

            rv = rv && decimal.TryParse(txtBeitrag1.Text, out dec) && decimal.TryParse(txtBeitrag2.Text, out dec) && decimal.TryParse(txtBeitrag3.Text, out dec);

            rv = rv && !txtBIC.Text.Equals("") && !txtGlaeubigerID.Text.Equals("") && !txtIBAN.Text.Equals("") && !txtName.Text.Equals("");

            return rv;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            if (DateTime.Now < new DateTime(DateTime.Now.Year, 03, 21))
                dTExecutionDate.Value = new DateTime(DateTime.Now.Year, 03, 21);
            else
                dTExecutionDate.Value = new DateTime(DateTime.Now.Year + 1, 03, 21);
        }

        private void CreateErrorReport(List<NaMiMitglied> failedMitglieder, string filename)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
            sw.WriteLine("Folgende Mitglieder haben keine Gültigen Konto Daten:\r\n");
            foreach (NaMiMitglied m in failedMitglieder)
            {
                sw.WriteLine(m.vorname + " " + m.nachname);
            }
            sw.Close();
            sw.Dispose();
        }
        string NormalizeString(string input)
        {
            return input.Replace("ä", "ae").Replace("Ä", "Ae").Replace("ö", "oe").Replace("Ö", "oe").Replace("ü", "ue").Replace("Ü", "Ue").Replace("-", " ").Replace("_", " ").Replace("ß", "ss");
        }
    }
}
