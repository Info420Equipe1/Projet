using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;

namespace Texcel.Interfaces.Jeu
{
    public partial class frmClassification : frmForm
    {
        public frmClassification()
        {
            InitializeComponent();
        }

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (ClassificationJeu classificationJeu in CtrlClassificationJeu.Rechercher())
            {
                cmbNom.Items.Add(classificationJeu.nomClassification);
            }
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassificationJeu classificationJeu = CtrlClassificationJeu.Rechercher(cmbNom.Text).First();
            //txtID.Text = classificationJeu.idClassification.ToString();
            txtCode.Text = classificationJeu.codeClassification;
            rtbDescription.Text = classificationJeu.descClassification;

            try
            {
                picClassification.Image = Image.FromFile(@"Images\Jeu\Classifications\" + classificationJeu.codeClassification + ".jpg");
                //picJeu.ImageLocation = @"..\..\Images\Jeu\"+jeu.idJeu+".jpg";
            }
            catch (FileNotFoundException)
            {
                picClassification.ImageLocation = @"Images\NoImage.png";
            }

            rtbDescription.SelectAll();
            txtCode.Enabled = false;
            btnEnregistrer.Text = "Modifier";
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            DialogResult DR;
            string message;

            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCode.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un code.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Validation
            if (CtrlClassificationJeu.VerifierClassificationJeu(cmbNom.Text.Trim()))
            {
                DR = MessageBox.Show("Vous êtes en train de modifier une classification de jeu, voulez-vous continuer?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    message = CtrlClassificationJeu.ModifierClassificationJeu(cmbNom.Text.Trim(), rtbDescription.Text.Trim());
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
                message = CtrlClassificationJeu.Ajouter(cmbNom.Text.Trim(), txtCode.Text.Trim(), rtbDescription.Text.Trim());
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbNom.Text = "";
                    txtCode.Text = "";
                    rtbDescription.Text = "";
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message;
            DialogResult DR;
            DR = MessageBox.Show("Voulez-vous vraiment supprimer cette classification: " + cmbNom.Text.ToString()+" ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                message = CtrlClassificationJeu.Supprimer(cmbNom.Text);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbNom.Text = "";
                    rtbDescription.Text = "";
                    btnEnregistrer.Text = "Enregistrer";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNom_TextUpdate(object sender, EventArgs e)
        {
            btnEnregistrer.Text = "Enregistrer";
            txtCode.Enabled = true;
        }
    }
}
