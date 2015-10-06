﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Texcel.Classes;

namespace Texcel.Interfaces
{
    public partial class frmLogin : frmForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    string message = CtrlLogin.VerifierLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    if (message == "Connexion réussie")
                    {
                        frmAdmin frmAdmin = new frmAdmin();
                        frmAdmin.Show();
                        this.Hide();          
                    }
                    else
                    {
                        MessageBox.Show("Connexion échouée, " + message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez saisir un mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir un nom d'utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            this.Close();
        }
    }
}
