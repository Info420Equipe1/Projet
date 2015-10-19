using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Test;
using Texcel.Classes;
using Texcel.Classes.Personnel;
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
            string cle = txtRechercher.Text.ToLower();
            dgvResultats.Columns.Clear();
            if (cmbFiltre.Text != "")
            {
                switch (cmbFiltre.Text)
                {
                    case "Plateforme":
                        dgvResultats.Columns.Add("0","Type de plateforme");
                        dgvResultats.Columns.Add("1","Plateforme");
                        tabControl1.SelectedIndex = 3;
                        foreach (AllPlateforme plat in CtrlAdmin.GetAllPlateformeView())
                        {
                            if (cle == "" || plat.nomTypePlateforme.ToLower().Contains(cle) || plat.nomPlateforme.ToLower().Contains(cle))
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
                        tabControl1.SelectedIndex = 4;
                        foreach (AllSysExp sysexp in CtrlAdmin.GetAllSysExpView())
                        {
                            if (cle == "" || sysexp.nomSysExp.ToLower().Contains(cle) || sysexp.codeSysExp.ToLower().Contains(cle) || sysexp.nomEdition.ToLower().Contains(cle) || (sysexp.noVersion ?? "").ToLower().Contains(cle))
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
                        tabControl1.SelectedIndex = 2;
                        foreach (cJeu jeu in CtrlAdmin.GetAllJeuView())
                        {
                            if (cle == "" || jeu.nomJeu.ToLower().Contains(cle) || jeu.developeur.ToLower().Contains(cle))
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
                        tabControl1.SelectedIndex = 1;
                        foreach (AllEquipe equipe in CtrlAdmin.GetAllEquipeView())
                        {
                            if (cle == "" || equipe.nomEquipe.ToLower().Contains(cle) || equipe.ChefEquipe.ToLower().Contains(cle))
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
                        tabControl1.SelectedIndex = 0;
                        foreach (Employe employe in CtrlAdmin.GetAllEmployeView())
                        {
                            if (cle == "" || employe.nomEmploye.ToLower().Contains(cle) || employe.prenomEmploye.ToLower().Contains(cle))
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
                string nomPren;
                nomPren = dgvResultats.SelectedRows[0].Cells[0].Value.ToString() + " " + dgvResultats.SelectedRows[0].Cells[1].Value.ToString();
                Employe emp = CtrlEmploye.emp(nomPren);
                frmAjouterEmploye frmEmp = new frmAjouterEmploye(emp.nomEmploye, emp.prenomEmploye, emp.adressePostale, emp.numTelPrincipal, emp.numTelSecondaire, emp.dateEmbauche, CtrlTypeTest.lstTypeTestAssEmp(emp), emp.competenceParticuliere, emp);
                frmEmp.ShowDialog();
                dgvResultats.Rows.Clear();
            }
        }

        private void dgvResultats_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Employé")
            {
                string nomPren;
                nomPren = dgvResultats.SelectedRows[0].Cells[0].Value.ToString() + " " + dgvResultats.SelectedRows[0].Cells[1].Value.ToString();
                Employe emp = CtrlEmploye.emp(nomPren);
                lblNoEmp.Text = emp.idEmploye.ToString();
                lblNomEmp.Text = emp.nomEmploye;
                lblPrenEmp.Text = emp.prenomEmploye;
                lblAdresseEmp.Text = emp.adressePostale;
                lblTelPrimEmp.Text = emp.numTelPrincipal;
                lblTelSecEmp.Text = emp.numTelSecondaire;
                dateTimePicker1.Value = emp.dateEmbauche;
                listBox1.Items.Clear();
                //foreach (TypeTest tT in CtrlTypeTest.lstTypeTestAssEmp(emp))
                //{
                //    listBox1.Items.Add(tT.nomTest);
                //}
                lstBoxTypeTest.Items.Clear();
                foreach (Utilisateur uti in CtrlUtilisateur.lstUtilisateurAssocEmp(emp))
                {
                    listBox1.Items.Add(uti.nomUtilisateur);
                }
                richTextBox1.Text = emp.competenceParticuliere;
            }
        }

        private void btnModifierEmp_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Employé")
            {
                string nomPren;
                nomPren = dgvResultats.SelectedRows[0].Cells[0].Value.ToString() + " " + dgvResultats.SelectedRows[0].Cells[1].Value.ToString();
                Employe emp = CtrlEmploye.emp(nomPren);
                frmAjouterEmploye frmEmp = new frmAjouterEmploye(emp.nomEmploye, emp.prenomEmploye, emp.adressePostale, emp.numTelPrincipal, emp.numTelSecondaire, emp.dateEmbauche, CtrlTypeTest.lstTypeTestAssEmp(emp), emp.competenceParticuliere, emp);
                frmEmp.ShowDialog();
                dgvResultats.Rows.Clear();
            }
        }
    }
}
