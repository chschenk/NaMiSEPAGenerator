using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NaMiSEPAGenerator
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            _mitgliedsnummer = "";
            _password = "";
        }
        private string _mitgliedsnummer;
        private string _password;
        public string Mitgliedsnummer
        {
            get
            {
                return _mitgliedsnummer;
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _password = txtPassword.Text;
            _mitgliedsnummer = txtMitgliedsnummer.Text;

            txtMitgliedsnummer.Text = "";
            txtPassword.Text = "";
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
