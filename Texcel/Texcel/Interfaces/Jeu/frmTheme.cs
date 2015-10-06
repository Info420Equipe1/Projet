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
    public partial class frmTheme : frmForm
    {
        public frmTheme()
        {
            InitializeComponent();
        }

        private void frmTheme_Load(object sender, EventArgs e)
        {
            // txtID.Text = (CtrlThemeJeu.GetCount() + 1).ToString();
        }

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (ThemeJeu Theme in CtrlThemeJeu.LstThemeJeu())
            {
                cmbNom.Items.Add(Theme.nomTheme);
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            DialogResult DR;
            string message;

            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validation
            if (CtrlThemeJeu.VerifierThemeJeu(cmbNom.Text.Trim()))
            {
                DR = MessageBox.Show("Vous êtes en train de modifier un thème de jeu, voulez-vous continuer?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    message = CtrlThemeJeu.ModifierTheme(cmbNom.Text, rtbCommentaire.Text);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                message = CtrlThemeJeu.Ajouter(cmbNom.Text.Trim(), rtbCommentaire.Text.Trim());
                
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    cmbNom.Text = "";
                    rtbCommentaire.Text = "";
                }
            }
        }
        

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomTheme = cmbNom.Text;

            ThemeJeu themeJeu = CtrlThemeJeu.GetTheme(nomTheme);
            txtID.Text = themeJeu.idTheme.ToString();
            rtbCommentaire.Text = themeJeu.commTheme;
            btnSupprimer.Visible = true;
            btnEnregistrer.Text = "Modifier";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message;
            DialogResult DR;
            DR = MessageBox.Show("Voulez-vous vraiment supprimer le thème: " + cmbNom.Text.ToString()+" ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                message = CtrlThemeJeu.Supprimer(cmbNom.Text);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtID.Text = "";
                    cmbNom.Text = "";
                    rtbCommentaire.Text = "";
                    btnSupprimer.Visible = false;
                    btnEnregistrer.Text = "Enregistrer";
                }
            }
            
        }

        private void cmbNom_TextUpdate(object sender, EventArgs e)
        {
            btnEnregistrer.Text = "Enregistrer";
            btnSupprimer.Visible = false;
            txtID.Text = "";
        }

        

        
    }
}
