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

namespace Texcel.Interfaces.Personnel
{
    public partial class frmUtilisateur : frmForm
    {
        bool ModifierUtilisateur;
        string NomUtilisateurAModifier;
        Employe EmployeLier;

        public frmUtilisateur(Employe _Employe)
        {
            InitializeComponent();
            EmployeLier = _Employe;
            ModifierUtilisateur = false;
            btnSupprimer.Visible = false;
        }
        public frmUtilisateur(string NomUtilisateur, string MotDePasse, List<Groupe> GroupeUtilisateur, Employe _Employe)
        {
            InitializeComponent();
            btnSupprimer.Visible = true;
            NomUtilisateurAModifier = NomUtilisateur;
            ModifierUtilisateur = true;
            EmployeLier = _Employe;
            txtNomUtil.Text = NomUtilisateur;
            txtMotPasse.Text = MotDePasse;
            foreach (Groupe groupe in GroupeUtilisateur)
            {
                lsbGroupes2.Items.Add(groupe.nomGroupe);
            }
        }

        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            if (!ModifierUtilisateur)
            {
                foreach (Groupe groupe in CtrlGroupe.GetAllGroupe())
                {
                    lsbGroupes.Items.Add(groupe.nomGroupe);
                }
            }
            else
            {
                foreach (Groupe groupe in CtrlGroupe.GetAllGroupe())
                {
                    if (!lsbGroupes2.Items.Contains(groupe.nomGroupe))
                    {
                        lsbGroupes.Items.Add(groupe.nomGroupe);
                    }
                }
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            string message;
            List<Groupe> lstGroupeUtilisateur = new List<Groupe>();

            if (!ModifierUtilisateur)
            {
                //Ajout d'un nouvel Utilisateur
                foreach (string nomGroupe in lsbGroupes2.Items)
                {
                    lstGroupeUtilisateur.Add(CtrlGroupe.GetGroupByName(nomGroupe));
                }
                message = CtrlUtilisateur.AjouterUtilisateur(txtNomUtil.Text, txtMotPasse.Text, lstGroupeUtilisateur, EmployeLier);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNomUtil.Text = "";
                    txtMotPasse.Text = "";
                    FillLsbGroupeDefault();
                }
            }
            else
            {
                //Modifier un Utilisateur existant
                foreach (string nomGroupe in lsbGroupes2.Items)
                {
                    lstGroupeUtilisateur.Add(CtrlGroupe.GetGroupByName(nomGroupe));
                }
                message = CtrlUtilisateur.ModifierUtilisateur(txtNomUtil.Text, txtMotPasse.Text, lstGroupeUtilisateur, NomUtilisateurAModifier);
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
        public void FillLsbGroupeDefault()
        {
            lsbGroupes2.Items.Clear();
            lsbGroupes.Items.Clear();
            foreach (Groupe groupe in CtrlGroupe.GetAllGroupe())
            {
                lsbGroupes.Items.Add(groupe.nomGroupe);
            }
        }

        //ajouter un groupe par rapport a l'utilisateur
        private void button1_Click(object sender, EventArgs e)
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
        private void button3_Click(object sender, EventArgs e)
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
        private void button4_Click(object sender, EventArgs e)
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
        private void button2_Click(object sender, EventArgs e)
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
            this.Close();
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
                    this.Close();
                }
            }
        }

        

       
    }
}
