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
    public partial class frmGenre : frmForm
    {
        public frmGenre()
        {
            InitializeComponent();
        }

        private void frmGenre_Load(object sender, EventArgs e)
        {
            txtID.Text = (CtrlGenreJeu.GetCount()+1).ToString();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            DialogResult DR;
            string message;

            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            //Validation
            if (CtrlGenreJeu.VerifierGenreJeu(cmbNom.Text.Trim()))
            {
                DR = MessageBox.Show("Vous ètes en train de modifier un Genre de jeu, voulez-vous continuer?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    message = CtrlGenreJeu.ModifierGenre(cmbNom.Text, rtbCommentaire.Text);
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
                message = CtrlGenreJeu.Ajouter(cmbNom.Text.Trim(), rtbCommentaire.Text.Trim());
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

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (GenreJeu Genre in CtrlGenreJeu.LstGenreJeu())
            {
                cmbNom.Items.Add(Genre.nomGenre);
            }
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomGenre = cmbNom.Text;

            GenreJeu genreJeu = CtrlGenreJeu.GetGenre(nomGenre);
            txtID.Text = genreJeu.idGenre.ToString();
            rtbCommentaire.Text = genreJeu.descGenre;
            rtbCommentaire.SelectAll();
            btnSupprimer.Visible = true;
            btnAjouter.Text = "Modifier";
        }

        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message;
            DialogResult DR;
            DR = MessageBox.Show("Voulez-vous vraiment supprimer le genre: " + cmbNom.Text.ToString()+" ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                message = CtrlGenreJeu.Supprimer(cmbNom.Text);
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
                    btnAjouter.Text = "Enregistrer";
                }
            }
        }

        private void cmbNom_TextUpdate(object sender, EventArgs e)
        {
            btnSupprimer.Visible = false;
            btnAjouter.Text = "Enregistrer";
        }
        
    }
}
