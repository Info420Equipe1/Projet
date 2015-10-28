using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;

namespace Texcel.Interfaces.Jeu
{
    public partial class frmAjouterVersionJeu : frmForm
    {
        string nomJeu;
        string versionJeu;
        public frmAjouterVersionJeu()
        {
            InitializeComponent();
        }
        public frmAjouterVersionJeu(string _nomJeu)
        {
            InitializeComponent();
            nomJeu = _nomJeu;
        }
        public frmAjouterVersionJeu(VersionJeu _versionJeu)
        {
            InitializeComponent();
            versionJeu = _versionJeu.nomVersionJeu;
            btnEnregistrer.Text = "Modifier";
            this.Text = "Modifier une Version de Jeu";
            txtNomVersion.Text = _versionJeu.nomVersionJeu;
            rtxtComm.Text = _versionJeu.commVersionJeu;
            txtNomVersion.Enabled = false;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string message;

            if (txtNomVersion.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (versionJeu == null)
            {
                if (CtrlVersionJeu.VerifierVersionJeu(txtNomVersion.Text.Trim()))
                {
                    MessageBox.Show("La version test du jeu existe déjà, veuillez choisir un autre nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    message = CtrlVersionJeu.Ajouter(txtNomVersion.Text.Trim(), rtxtComm.Text.Trim(), nomJeu);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNomVersion.Text = "";
                        rtxtComm.Text = "";
                    }
                }
            }
            else
            {
                message = CtrlVersionJeu.Modifier(txtNomVersion.Text.Trim(), rtxtComm.Text.Trim());
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAjouterVersionJeu_Shown(object sender, EventArgs e)
        {
            if (versionJeu != null)
            {
                rtxtComm.Focus();
                rtxtComm.SelectAll();
            }
            else
            {
                txtNomVersion.Focus();
            }
        }

       
    }
}
