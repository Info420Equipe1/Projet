﻿using System;
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
    public partial class frmTypePlateforme : frmForm
    {
        

        public frmTypePlateforme()
        {
            InitializeComponent();
            
        }

        private void frmTypePlateforme_Load(object sender, EventArgs e)
        {
            //txtID.Text = (CtrlTypePlateforme.GetCount() + 1).ToString();
        }  

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (TypePlateforme typePlat in CtrlTypePlateforme.Rechercher())
            {
                cmbNom.Items.Add(typePlat.nomTypePlateforme);
            }
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomTypePlat = cmbNom.Text;

            TypePlateforme typePlat = CtrlTypePlateforme.GetTypePlateforme(nomTypePlat);
            txtID.Text = typePlat.idTypePlateforme.ToString();
            rtbCommentaire.Text = typePlat.descTypePlateforme;
            btnSupprimer.Visible = true;
            btnEnregistrer.Text = "Modifier";
        }

        private void cmbNom_TextUpdate_1(object sender, EventArgs e)
        {
            foreach (TypePlateforme plat in CtrlTypePlateforme.Rechercher())
            {
                if (cmbNom.Text != plat.nomTypePlateforme)
                {
                    btnEnregistrer.Text = "Enregistrer";
                    btnSupprimer.Visible = false;
                    txtID.Text = "";
                }
            }
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult DR;
            string message;

            if (CtrlTypePlateforme.Verifier(cmbNom.Text.Trim()))
            {
                message = "Vous êtes en train de modifier un type de plateforme, voulez-vous continuer?";
                DR = MessageBox.Show(message, "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    message = CtrlTypePlateforme.Modifier(cmbNom.Text, rtbCommentaire.Text);
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
                message = CtrlTypePlateforme.Ajouter(cmbNom.Text.Trim(), rtbCommentaire.Text.Trim());
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

        private void btnSupprimer_Click_1(object sender, EventArgs e)
        {
            string message;
            DialogResult DR = MessageBox.Show("Voulez-vous vraiment supprimer ce type de plateforme?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                message = CtrlTypePlateforme.Supprimer(cmbNom.Text);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       

        

        
    }
}
