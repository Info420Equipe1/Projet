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
        static string nomJeu;
        bool modif;
        public frmAjouterVersionJeu()
        {
            InitializeComponent();
            fillDropDownJeu();
            modif = false;
        }
        public frmAjouterVersionJeu(string _nomJeu)
        {
            InitializeComponent();
            fillDropDownJeu();
            nomJeu = _nomJeu;
            cmbJeux.SelectedItem = nomJeu;
            modif = false;
        }
        public frmAjouterVersionJeu(VersionJeu _versionJeu)
        {
            InitializeComponent();
            fillDropDownJeu();
            modif = true;
            cmbJeux.SelectedItem = _versionJeu.cJeu.nomJeu;
            btnEnregistrer.Text = "Modifier";
            this.Text = "Modifier une Version de Jeu";
            txtNomVersion.Text = _versionJeu.nomVersionJeu;
            rtxtComm.Text = _versionJeu.commVersionJeu;
            txtNomVersion.Enabled = false;
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string message;
            if (cmbJeux.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez ajouter un jeu afin de lier la version au jeu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtNomVersion.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom pour la version.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!modif)
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
                message = CtrlVersionJeu.Modifier(txtNomVersion.Text.Trim(), rtxtComm.Text.Trim(), nomJeu);
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
        private void fillDropDownJeu()
        {
            cmbJeux.Items.Clear();
            foreach (cJeu jeu in CtrlJeu.LstJeu())
	        {
                cmbJeux.Items.Add(jeu.nomJeu);
	        }
        }

        private void frmAjouterVersionJeu_Shown(object sender, EventArgs e)
        {
            if (modif)
            {
                rtxtComm.Focus();
                rtxtComm.SelectAll();
            }
            else
            {
                txtNomVersion.Focus();
            }
        }

        private void cmbJeux_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJeux.SelectedIndex != -1)
            {
                nomJeu = cmbJeux.SelectedItem.ToString();
            }
        }

       
    }
}
