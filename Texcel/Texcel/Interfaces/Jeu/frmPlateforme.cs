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
    public partial class frmPlateforme : frmForm
    {
        bool modif;
        Plateforme platModif;
        List<EditionSysExp> lstEd = new List<EditionSysExp>();
        public frmPlateforme()
        {
            InitializeComponent();
            modif = false;
            txtID.Text = (CtrlPlateforme.GetCount() + 1).ToString();
            cmbNom.DropDownStyle = ComboBoxStyle.DropDown;
        }
        public frmPlateforme(Plateforme plat)
        {
            InitializeComponent();
            txtID.Enabled = false;
            txtID.Text = plat.idPlateforme.ToString();
            cmbTypePlateforme.Enabled = false;
            cmbTypePlateforme.Items.Add(plat.TypePlateforme.nomTypePlateforme);
            cmbTypePlateforme.SelectedIndex = 0;
            //cmbTypePlateforme.SelectedIndex = cmbTypePlateforme.Items.IndexOf(plat.TypePlateforme.nomTypePlateforme);
            cmbNom.Enabled = true;
            cmbNom.AllowDrop = false;
            cmbNom.Text = plat.nomPlateforme;
            rtbConfiguration.Text = plat.configPlateforme;
            rtbCommentaire.Text = plat.commPlateforme;
            //Probleme à discuter
            //SysExp SE = plat.SysExp.First();
            //cmbNomSE.Text = SE.nomSysExp;
            //EditionSysExp EditionSE = SE.EditionSysExp.First();
            //cmbEditionSE.Text = EditionSE.nomEdition;
            //VersionSysExp VersionSE = EditionSE.VersionSysExp.First();
            //cmbVersionSE.Text = VersionSE.noVersion;
            btnAjouter.Text = "Modifier";
            modif = true;
            platModif = plat;
            
        }

        


        // fill la  liste de type plateforme
        private void cmbTypePlateforme_DropDown(object sender, EventArgs e)
        {
            cmbTypePlateforme.Items.Clear();
            foreach (TypePlateforme typePlat in CtrlTypePlateforme.getLstTypePlateforme())
            {
                cmbTypePlateforme.Items.Add(typePlat.nomTypePlateforme);
            }
        }

        private void cmbTypePlateforme_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbNom.Text = "Aucun";
            if (cmbTypePlateforme.Text != "")
            {
                cmbNom.Enabled = true;
            }
            else
            {
                cmbNom.Enabled = false;
            }
            Recharger2();
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            grbSE.Enabled = true;
            if (CtrlPlateforme.Verifier(cmbNom.Text))
            {
                //Plateforme plateforme = CtrlPlateforme.GetPlateforme(cmbNom.Text);
                //txtID.Text = plateforme.idPlateforme.ToString();
                //Changer lors de la creation BD descPlateforme à commPlateforme
                //rtbCommentaire.Text = plateforme.commPlateforme;
                //rtbConfiguration.Text = plateforme.configPlateforme;
                //rtbCommentaire.SelectAll();
                //btnAjouter.Text = "Modifier";
                //btnAjouter.Visible = false;
                //btnSupprimer.Visible = true;
            }
        }

        private void cmbNom_TextUpdate(object sender, EventArgs e)
        {
            //if (cmbNom.Text.Trim() == null || cmbNom.Text.Trim() == "" || cmbNom.Text.Trim() == "Aucun")
            //{
            //    grbSE.Enabled = false;
            //    //btnAjouter.Text = "Modifier";
            //}
            //else
            //{
            //    grbSE.Enabled = true;
            //    btnAjouter.Visible = true;
            //    btnAjouter.Text = "Enregistrer";
            //    btnSupprimer.Visible = false;
            //    txtID.Text = "";
            //    rtbConfiguration.Text = "";
            //    rtbCommentaire.Text = "";
            //}
        }

        // fill la  liste de plateforme
        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (Plateforme Plat in CtrlPlateforme.Rechercher(cmbTypePlateforme.Text))
            {
                cmbNom.Items.Add(Plat.nomPlateforme);
            }
        }

        // fill la  liste de nom de sysExp
        private void cmbNomSE_DropDown(object sender, EventArgs e)
        {
            cmbNomSE.Items.Clear();


            foreach (SysExp sysExp in CtrlSysExp.Rechercher())
            {
                cmbNomSE.Items.Add(sysExp.nomSysExp);

            }
        }

        private void pcbAjouterSE_Click(object sender, EventArgs e)
        {
            frmAjouterSysExp frmSysExp = new frmAjouterSysExp();
            frmSysExp.ShowDialog();
        }

        //BOuton click d'enregistrer une plateforme
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            //DialogResult DR;
            string message;

            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTypePlateforme.Text == "")
            {
                MessageBox.Show("Veuillez choisir un type de plateforme", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (modif)
            {
                if (cmbNomSE.Text == "")
                {


                    message = CtrlPlateforme.Modifier(cmbNom.Text, rtbConfiguration.Text, rtbCommentaire.Text, platModif);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Recharger();
                    }
                    
                }
                else
                {

                    message = CtrlPlateforme.LierPlateformeSysExp(platModif, cmbNomSE.Text.Trim(), cmbNom.Text, rtbConfiguration.Text, rtbCommentaire.Text);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Recharger();
                    }
                }
                this.Close();
            }
            else
            {
                if (cmbNomSE.Text == "")
                {
                    message = CtrlPlateforme.CreerPlateforme(CtrlTypePlateforme.getPlatByName(cmbTypePlateforme.Text), cmbNom.Text.Trim(), rtbConfiguration.Text.Trim(), rtbCommentaire.Text.Trim());
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Recharger();
                    }
                }
                else
                {
                    message = CtrlPlateforme.Ajouter(CtrlTypePlateforme.getPlatByName(cmbTypePlateforme.Text), cmbNom.Text.Trim(), rtbCommentaire.Text.Trim(), rtbConfiguration.Text.Trim(), cmbNomSE.Text.Trim());
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Recharger();
                    }
                }

            }
        }
        //Recharger tout
        private void Recharger()
        {
            //txtID.Text = (CtrlPlateforme.GetCount() + 1).ToString();
            rtbCommentaire.Text = "";
            rtbConfiguration.Text = "";
            cmbNom.Text = "";
            cmbTypePlateforme.SelectedItem = null;
            cmbNomSE.SelectedItem = null;
            cmbVersionSE.SelectedItem = null;
            cmbEditionSE.SelectedItem = null;
        }
        //Recharger sans enlever le type de test
        private void Recharger2()
        {
            rtbCommentaire.Text = "";
            rtbConfiguration.Text = "";
            cmbNom.Text = "";
            cmbNomSE.SelectedItem = null;
            cmbVersionSE.SelectedItem = null;
            cmbEditionSE.SelectedItem = null;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message;
            DialogResult DR;
            DR = MessageBox.Show("Voulez-vous vraiment supprimer la plateforme: " + cmbNom.Text.ToString() +" ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                if (cmbNomSE.Text == "")
                {
                    message = CtrlPlateforme.Supprimer(cmbNom.Text);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Recharger();
                    }
                }
                else
                {
                    message = CtrlPlateforme.SupprimerPlaSysExp(cmbNom.Text, cmbNomSE.Text);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Recharger();
                    }
                }


                //btnSupprimer.Visible = false;
                //btnAjouter.Text = "Enregistrer";
            }
            TypePlateforme tp = CtrlTypePlateforme.getPlatByName(cmbTypePlateforme.Text);
            //CtrlPlateforme.Ajouter(tp, cmbNom.Text, rtbConfiguration.Text, rtbCommentaire.Text);
        }

        private void cmbEditionSE_DropDown(object sender, EventArgs e)
        {
            cmbEditionSE.Items.Clear();


            foreach (EditionSysExp ed in CtrlEditionSysExp.RechercherpourListe(cmbNomSE.Text))
            {
                cmbEditionSE.Items.Add(ed.nomEdition);

            }
        }

        private void cmbVersionSE_DropDown(object sender, EventArgs e)
        {
            cmbVersionSE.Items.Clear();

            foreach (String ver in CtrlVersionSysExp.RechercherpourListe(cmbEditionSE.Text))
            {
                cmbVersionSE.Items.Add(ver);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNomSE_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nomSysExp = ((ComboBox)sender).Text;
            SysExp sysExp = CtrlSysExp.GetSysExp(nomSysExp);
            try
            {
                picSysExp.Image = Image.FromFile(@"..\..\Images\Jeu\SysExp\" + sysExp.codeSysExp + "logo.png");
            }
            catch (Exception)
            {
                picSysExp.Image = Image.FromFile(@"C:\Users\Utilisateur\Documents\GitHub\Projet\Texcel\Texcel\Images\NoImage.png");
            }
        }


    }
}
