using System;
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

namespace Texcel.Interfaces.Personnel
{
    public partial class frmUtilisateur : frmForm
    {
        bool ModifierUtilisateur;
        string NomUtilisateurAModifier;
        Employe EmployeLier;
        frmAjouterEmploye frmAjouEmp;
        Utilisateur monUti;

        public frmUtilisateur()
        {

        }

        //Construteur avec employé
        public frmUtilisateur(Employe _Employe, frmAjouterEmploye _rfmAjou)
        {
            InitializeComponent();
            EmployeLier = _Employe;
            ModifierUtilisateur = false;
            btnSupprimer.Visible = false;
            frmAjouEmp = _rfmAjou;
        }
        //Constructeur avec info de modification
        public frmUtilisateur(string _NomUtilisateur, string _MotDePasse, List<Groupe> _GroupeUtilisateur, Employe _Employe, frmAjouterEmploye _rfmAjou)
        {
            InitializeComponent();
            btnSupprimer.Visible = true;
            NomUtilisateurAModifier = _NomUtilisateur;
            ModifierUtilisateur = true;
            EmployeLier = _Employe;
            txtNomUtil.Text = _NomUtilisateur;
            txtMotPasse.Text = _MotDePasse;
            frmAjouEmp = _rfmAjou;
            monUti = CtrlUtilisateur.getUtilisateur(_NomUtilisateur);

        }

        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            Réaffichage();
        }

        private void Réaffichage()
        {
            lsbGroupes.Items.Clear();
            lsbGroupes2.Items.Clear();

           if (!ModifierUtilisateur)
            {
                foreach (Groupe groupe in CtrlGroupe.GetAllGroupe())
                {
                    lsbGroupes.Items.Add(groupe.nomGroupe);
                }
            }
            else
            {
                foreach (Groupe grp in CtrlGroupe.GetAllGroupe())
                {
                    lsbGroupes.Items.Add(grp.nomGroupe);
                }

                foreach (Groupe groupe in monUti.Groupe)
                {
                    lsbGroupes2.Items.Add(groupe.nomGroupe);
                    lsbGroupes.Items.Remove(groupe.nomGroupe);

                }
            }        
        }

        // Bouton enregistrer et/ou modifier
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string message;
            List<Groupe> lstGroupeUtilisateur = new List<Groupe>();

            //Ajout d'un nouvel Utilisateur si false
            if (!ModifierUtilisateur)
            {
                //affiche groupe dans liste
                foreach (string nomGroupe in lsbGroupes2.Items)
                {
                    lstGroupeUtilisateur.Add(CtrlGroupe.GetGroupByName(nomGroupe));
                }

                message = CtrlUtilisateur.AjouterUtilisateur(txtNomUtil.Text, txtMotPasse.Text, lstGroupeUtilisateur, EmployeLier);
                if (message.Contains("erreur"))
                {
                    CtrlController.MessageWarnng(message);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomUtil.Text = "";
                    txtMotPasse.Text = "";
                    Réaffichage();
                }
               
            }
            //Modifier un Utilisateur existant
            else
            {
                
                foreach (string nomGroupe in lsbGroupes2.Items)
                {
                    lstGroupeUtilisateur.Add(CtrlGroupe.GetGroupByName(nomGroupe));
                }

                message = CtrlUtilisateur.ModifierUtilisateur(txtNomUtil.Text, txtMotPasse.Text, lstGroupeUtilisateur, NomUtilisateurAModifier);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Réaffichage();
                    return;
                    
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FermetureForm();
                }              
                
                
            }
            
          
        }
       
        //ajouter un groupe par rapport a l'utilisateur
        private void btnPtiteFlecheDroite_Click(object sender, EventArgs e)
        {
            if ((lsbGroupes.Items.Count == 0) || (lsbGroupes.SelectedIndex == -1) || (lsbGroupes.SelectedItems.Count > 1))
            {
                MessageBox.Show("Veuillez selectionner un groupe à ajouter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomGroupe = (string)lsbGroupes.SelectedItem;
            lsbGroupes.Items.Remove(nomGroupe);
            lsbGroupes2.Items.Add(nomGroupe);
        }

        //ajouter plusieurs groupes par rapport a l'utilisateur
        private void btn2FlecheDroite_Click(object sender, EventArgs e)
        {
            if ((lsbGroupes.Items.Count == 0) || (lsbGroupes.SelectedIndex == -1) || (lsbGroupes.SelectedItems.Count < 2))
            {
                MessageBox.Show("Veuillez selectionner plusieurs groupes à ajouter", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListBox.SelectedObjectCollection lstBoxSOC = lsbGroupes.SelectedItems;
            string groupeName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                groupeName = lstBoxSOC[0].ToString();
                lsbGroupes.Items.Remove(groupeName);
                lsbGroupes2.Items.Add(groupeName);
            }
        }

        //Remove plusieurs groupes par rapport a l'utilisateur
        private void btn2FlecheGauche_Click(object sender, EventArgs e)
        {
            if ((lsbGroupes2.Items.Count == 0) || (lsbGroupes2.SelectedIndex == -1) || (lsbGroupes2.SelectedItems.Count < 2))
            {
                MessageBox.Show("Veuillez selectionner plusieurs groupes à enlever.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ListBox.SelectedObjectCollection lstBoxSOC = lsbGroupes2.SelectedItems;
            string groupeName;
            int selectedItems = lstBoxSOC.Count;
            for (int i = 0; i < selectedItems; i++)
            {
                groupeName = lstBoxSOC[0].ToString();
                lsbGroupes2.Items.Remove(groupeName);
                lsbGroupes.Items.Add(groupeName);
            }
        }

        //Remove un groupe par rapport a l'utilisateur
        private void btnPtiteFlecheGauche_Click(object sender, EventArgs e)
        {
            if ((lsbGroupes2.Items.Count == 0) || (lsbGroupes2.SelectedIndex == -1) || (lsbGroupes2.SelectedItems.Count > 1))
            {
                MessageBox.Show("Veuillez selectionner un groupe à enlever.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomGroupe = (string)lsbGroupes2.SelectedItem;
            lsbGroupes2.Items.Remove(lsbGroupes2.SelectedItem);
            lsbGroupes.Items.Add(nomGroupe);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FermetureForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string message;
            DialogResult DR;
            DR = MessageBox.Show("Voulez-vous vraiment désactiver l'utilisateur: " + NomUtilisateurAModifier.ToString() + " ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                message = CtrlUtilisateur.SupprimerUtilisateur(NomUtilisateurAModifier);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FermetureForm();
                                        
                }
            }
        }
        private void FermetureForm()
        {          
            this.Close();
            Réaffichage();
            frmAjouEmp.ActualiserLstCompte(); 

        }

        private void frmUtilisateur_FormClosed(object sender, FormClosedEventArgs e)
        {
            FermetureForm();
        }
     
    }
}
