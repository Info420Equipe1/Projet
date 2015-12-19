﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Personnel;

using Texcel.Classes;

namespace Texcel.Interfaces
{
    public partial class frmLogin : frmForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        // S'execute lorsque l'utilisateur appuit sur le bouton connexion
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (txtUsername.Text != "")
            {
                if (txtPassword.Text != "")
                {
                    string message = CtrlLogin.VerifierLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    if (message == "Connexion réussie")
                    {
                     
                        this.Close();
                        List<Form> lstForm = new List<Form>();
                        foreach (Form form in Application.OpenForms)
                        {
                            lstForm.Add(form);
                        }

                        foreach (Form form in lstForm)
                        {
                            form.WindowState = FormWindowState.Maximized;
                            form.Visible = true;
                        } 
                    }
                    else if (message == "Vous devez changer de mot de passe")
                    {
                        frmPassRenew frmPassRenew = new frmPassRenew(CtrlUtilisateur.getUtilisateur(txtUsername.Text));
                        frmPassRenew.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            Cursor.Current = Cursors.Default;
        }

        // S'execute lorsque l'utilisateur appuit sur le bouton annuler
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // S'execute lorsque la form se ferme
        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtPassword.Text == "" && txtUsername.Text == "")
            {
                Application.Exit();
            }
        }

        // S'execute lorsque l'utilisateur appuit sur une touche dans le champ mot de passe
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
