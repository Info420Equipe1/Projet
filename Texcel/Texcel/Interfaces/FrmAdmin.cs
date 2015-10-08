using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Texcel.Classes;

using Texcel.Interfaces.Jeu;
using Texcel.Interfaces.Personnel;

namespace Texcel.Interfaces
{
    public partial class frmAdmin : frmForm
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            int n = 0;
            string cle = txtRechercher.Text;
            dgvResultats.Columns.Clear();
            if (cmbFiltre.Text != "")
            {
                switch (cmbFiltre.Text)
                {
                    case "Plateforme":
                        dgvResultats.Columns.Add("0","Type de plateforme");
                        dgvResultats.Columns.Add("1","Plateforme");
                        foreach (AllPlateforme plat in CtrlAdmin.GetAllPlateformeView())
                        {
                            if (cle == "" || plat.nomTypePlateforme.Contains(cle) || plat.nomPlateforme.Contains(cle))
                            {
                                dgvResultats.Rows.Add();
                                dgvResultats.Rows[n].Cells[0].Value = plat.nomTypePlateforme;
                                dgvResultats.Rows[n].Cells[1].Value = plat.nomPlateforme;
                                n++; 
                            }
                        }
                        break;

                    case "Système d'exploitation":
                        dgvResultats.Columns.Add("0", "Système d'exploitation");
                        dgvResultats.Columns.Add("1", "Code");
                        dgvResultats.Columns.Add("2", "Edition");
                        dgvResultats.Columns.Add("3", "Version");
                        foreach (AllSysExp sysexp in CtrlAdmin.GetAllSysExpView())
                        {
                            if (cle == "" || sysexp.nomSysExp.Contains(cle) || sysexp.codeSysExp.Contains(cle) || sysexp.nomEdition.Contains(cle) || (sysexp.noVersion ?? "").Contains(cle))
                            {
                                dgvResultats.Rows.Add();
                                dgvResultats.Rows[n].Cells[0].Value = sysexp.nomSysExp;
                                dgvResultats.Rows[n].Cells[1].Value = sysexp.codeSysExp;
                                dgvResultats.Rows[n].Cells[2].Value = sysexp.nomEdition;
                                dgvResultats.Rows[n].Cells[3].Value = sysexp.noVersion;
                                n++; 
                            }
                        }
                        break;

                    case "Jeu":
                        dgvResultats.Columns.Add("0", "Jeu");
                        dgvResultats.Columns.Add("1", "Developpeur");
                        foreach (cJeu jeu in CtrlAdmin.GetAllJeuView())
                        {
                            if (cle == "" || jeu.nomJeu.Contains(cle) || jeu.developeur.Contains(cle))
                            {
                                dgvResultats.Rows.Add();
                                dgvResultats.Rows[n].Cells[0].Value = jeu.nomJeu;
                                dgvResultats.Rows[n].Cells[1].Value = jeu.developeur;
                                n++; 
                            }
                        }
                        break;

                    case "Équipe":
                        dgvResultats.Columns.Add("0", "Équipe");
                        dgvResultats.Columns.Add("1", "Chef d'équipe");
                        foreach (AllEquipe equipe in CtrlAdmin.GetAllEquipeView())
                        {
                            if (cle == "" || equipe.nomEquipe.Contains(cle) || equipe.ChefEquipe.Contains(cle))
                            {
                                dgvResultats.Rows.Add();
                                dgvResultats.Rows[n].Cells[0].Value = equipe.nomEquipe;
                                dgvResultats.Rows[n].Cells[1].Value = equipe.ChefEquipe;
                                n++; 
                            }
                        }
                        break;

                    case "Employé":
                        dgvResultats.Columns.Add("0", "Nom");
                        dgvResultats.Columns.Add("1", "Prenom");
                        foreach (Employe employe in CtrlAdmin.GetAllEmployeView())
                        {
                            if (cle == "" || employe.nomEmploye.Contains(cle) || employe.prenomEmploye.Contains(cle))
                            {
                                dgvResultats.Rows.Add();
                                dgvResultats.Rows[n].Cells[0].Value = employe.nomEmploye;
                                dgvResultats.Rows[n].Cells[1].Value = employe.prenomEmploye;
                                n++; 
                            }
                        }
                        break;
                }
            }
        }

        private void SmiSysExp_Click(object sender, EventArgs e)
        {
            frmAjouterSysExp frmSysExp = new frmAjouterSysExp();
            frmSysExp.ShowDialog();
        }

        private void SmiTypePlateforme_Click(object sender, EventArgs e)
        {
            frmTypePlateforme frmTypePlateforme = new frmTypePlateforme();
            frmTypePlateforme.ShowDialog();
        }

        private void SmiPlateforme_Click(object sender, EventArgs e)
        {
            frmPlateforme frmPlateforme = new frmPlateforme();
            frmPlateforme.ShowDialog();
        }

        private void SmiTheme_Click(object sender, EventArgs e)
        {
            frmTheme frmTheme = new frmTheme();
            frmTheme.ShowDialog();
        }

        private void SmiGenre_Click(object sender, EventArgs e)
        {
            frmGenre frmGenre = new frmGenre();
            frmGenre.ShowDialog();
        }

        private void SmiClassification_Click(object sender, EventArgs e)
        {
            frmClassification frmClassification = new frmClassification();
            frmClassification.ShowDialog();
        }

        private void SmiJeu_Click(object sender, EventArgs e)
        {
            frmJeu frmJeu = new frmJeu();
            frmJeu.ShowDialog();
        }

        private void SmiPersonnel_Click(object sender, EventArgs e)
        {
            frmAjouterEmploye frmAjouterEmploye = new frmAjouterEmploye();
            frmAjouterEmploye.ShowDialog();
        }

        private void smiEmploye_Click(object sender, EventArgs e)
        {
            frmAjouterEmploye frmAjouterEmploye = new frmAjouterEmploye();
            frmAjouterEmploye.Show();
        }

        private void smiEquipe_Click(object sender, EventArgs e)
        {
            frmCreerEquipe frmCreerEquipe = new frmCreerEquipe();
            frmCreerEquipe.ShowDialog();
        }

        private void smiQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

            foreach (Groupe groupe in CtrlController.GetCurrentUser().Groupe)
            {
                if (groupe.idGroupe == 1)
                {
                    MessageBox.Show("Un directeur de compte est connecté");
                    cmbFiltre.Text = "Jeu";
                    smiGestionJeu.Visible = false;
                    smiGestionPersonnel.Visible = false;
                }
                else if (groupe.idGroupe == 2)
                {
                    MessageBox.Show("Un chef de projet est connecté");
                    cmbFiltre.Text = "Equipe";
                    smiGestionJeu.Visible = false;
                    smiEmploye.Visible = false;
                }
                else if(groupe.idGroupe == 3)
                {
                    MessageBox.Show("Un chef d'équipe est connecté");
                    cmbFiltre.Text = "Employé";
                    smiGestionJeu.Visible = false;
                    smiEmploye.Visible = false;
                }
                else if (groupe.idGroupe == 4)
                {
                    MessageBox.Show("Un testeur est connecté");
                    cmbFiltre.Text = "Jeu";
                    smiGestionJeu.Visible = false;
                    smiGestionPersonnel.Visible = false;
                }
                else if (groupe.idGroupe == 5)
                {
                    MessageBox.Show("Un administrateur du système est connecté");
                }
            }
        }

        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRechercher.Clear();
            dgvResultats.Columns.Clear();
        }

        private void dgvResultats_DoubleClick(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Employé")
            {
                
            }
        }
    }
}
