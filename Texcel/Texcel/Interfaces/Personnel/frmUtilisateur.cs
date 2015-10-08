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
        public frmUtilisateur()
        {
            InitializeComponent();
            ModifierUtilisateur = false;
        }
        public frmUtilisateur(string NomUtilisateur, string MotDePasse, List<Groupe> GroupeUtilisateur)
        {
            InitializeComponent();
            ModifierUtilisateur = true;
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
            if (!ModifierUtilisateur)
            {
                //Ajout d'un nouvel Utilisateur
                List<Groupe> lstGroupeUtilisateur = new List<Groupe>();
                foreach (string nomGroupe in lsbGroupes2.Items)
                {
                    lstGroupeUtilisateur.Add(CtrlGroupe.GetGroupByName(nomGroupe));
                }
                string message = CtrlUtilisateur.AjouterUtilisateur(txtNomUtil.Text, txtMotPasse.Text, lstGroupeUtilisateur);
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
                    lsbGroupes2.Items.Clear();
                    FillLsbGroupeDefault();
                }
                
            }
            else
            {
                //Modifier un Utilisateur existant
                List<Groupe> lstGroupeUtilisateur = new List<Groupe>();
                foreach (string nomGroupe in lsbGroupes2.Items)
                {
                    lstGroupeUtilisateur.Add(CtrlGroupe.GetGroupByName(nomGroupe));
                }
            }
        }
        public void FillLsbGroupeDefault()
        {
            lsbGroupes.Items.Clear();
            foreach (Groupe groupe in CtrlGroupe.GetAllGroupe())
            {
                lsbGroupes.Items.Add(groupe.nomGroupe);
            }
        }
       
    }
}
