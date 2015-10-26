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
using Texcel.Classes.Projet;
using Texcel.Classes.Jeu;
using Texcel.Interfaces.Jeu;
using Texcel.Interfaces.Personnel;

namespace Texcel.Interfaces
{
    public partial class frmAdmin : frmForm
    {
        List<int> lstDroits;
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void frmAdmin_Shown(object sender, EventArgs e)
        {
            foreach (Groupe groupe in CtrlController.GetCurrentUser().Groupe)
            {
                lstDroits = CtrlController.GetDroits(groupe);
                if (groupe.idGroupe == 2)
                {
                    cmbFiltre.Text = "Équipe";
                    btnRechercher_Click(this, null);
                }
                if (groupe.idGroupe == 3)
                {
                    cmbFiltre.Text = "Employé";
                    btnRechercher_Click(this, null);
                }
                if (groupe.idGroupe == 5)
                {
                    //MessageBox.Show("Un administrateur du système est connecté");
                    //Verification du fichier RH
                    cmbFiltre.Text = "Jeu";
                    btnRechercher_Click(this, null);
                    if (CtrlFileEmployes.IsEmpty() > 0)
                    {
                        DialogResult dr = MessageBox.Show("De nouveaux employés ont été envoyé par les RH. Désirez-vous les ajouter?", "Nouveaux employés", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dr == DialogResult.Yes)
                        {
                            frmEmployeRecu frmEmployeRecu = new frmEmployeRecu();
                            frmEmployeRecu.ShowDialog();
                        }
                    }
                }
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            ChoixFiltre(cmbFiltre.Text);
            dgvResultats_Click(this, null);
        }

        // Pour déterminer et afficher la liste d'éléments selon le filtre choisi
        private void ChoixFiltre(string _nomFiltre)
        {
            int n = 0;
            string cle = txtRechercher.Text.ToLower();
            dgvResultats.Columns.Clear();

            // si aucun filtre n'est sélectionner????
            //J'ai ajouté un default avec un messagebox qui dit d'en selectionner un, à discuter
            switch (_nomFiltre)
            {
                case "Plateforme":
                    dgvResultats.Columns.Add("0", "Type de plateforme");
                    dgvResultats.Columns.Add("1", "Plateforme");
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
                    //bug ici
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
                    int id = 1;
                    foreach (AllEquipe equipe in CtrlAdmin.GetAllEquipeView())
                    {
                        if (cle == "" || equipe.nomEquipe.ToLower().Contains(cle) || equipe.ChefEquipe.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Tag = id;
                            dgvResultats.Rows[n].Cells[0].Value = equipe.nomEquipe;
                            dgvResultats.Rows[n].Cells[1].Value = equipe.ChefEquipe;
                            id++;
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

                default : 
                    MessageBox.Show("Veuillez sélectionner un filtre.", "Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
        }

        private void messageDroits()
        {
            MessageBox.Show("Vous ne possédez pas les droits requis pour accéder à cette section. Contactez votre administrateur pour plus de détails. ", "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SmiSysExp_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(2))
            {
                frmAjouterSysExp frmSysExp = new frmAjouterSysExp();
                frmSysExp.ShowDialog(); 
            }
            else
            {
                messageDroits();
            }
        }

        private void SmiTypePlateforme_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(10))
            {
                frmTypePlateforme frmTypePlateforme = new frmTypePlateforme();
                frmTypePlateforme.ShowDialog(); 
            }
            else
            {
                messageDroits();
            }
        }

        private void SmiPlateforme_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(14))
            {
                frmPlateforme frmPlateforme = new frmPlateforme();
                frmPlateforme.ShowDialog(); 
            }
            else
            {
                messageDroits();
            }
        }

        private void SmiTheme_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(12))
            {
                frmTheme frmTheme = new frmTheme();
                frmTheme.ShowDialog(); 
            }
            else
            {
                messageDroits();
            }
        }

        private void SmiGenre_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(6))
            {
                frmGenre frmGenre = new frmGenre();
                frmGenre.ShowDialog(); 
            }
            else
            {
                messageDroits();
            }
        }

        private void SmiClassification_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(4))
            {
                frmClassification frmClassification = new frmClassification();
                frmClassification.ShowDialog(); 
            }
            else
            {
                messageDroits();
            }
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

        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRechercher.Clear();
            dgvResultats.Columns.Clear();
            //ChoixFiltre(cmbFiltre.Text);
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
                lstBoxTypeTest.Items.Clear();
                foreach (TypeTest tT in CtrlTypeTest.lstTypeTestAssEmp(emp))
                {
                    lstBoxTypeTest.Items.Add(tT.nomTypeTest);
                }
               
                foreach (Utilisateur uti in CtrlUtilisateur.lstUtilisateurAssocEmp(emp))
                {
                    listBox1.Items.Add(uti.nomUtilisateur);
                }
                richTextBox1.Text = emp.competenceParticuliere;
            }
            else if (cmbFiltre.Text == "Équipe")
            {
                string nomChefEquipe = dgvResultats.SelectedRows[0].Cells[1].Value.ToString();
                int id = Convert.ToInt16(dgvResultats.SelectedRows[0].Cells[0].Tag);
                Equipe selectedEquipe = CtrlEquipe.getSelectedEquipe(id);
                lblNomEquipe.Text = selectedEquipe.nomEquipe;
                lblChefEquipe.Text = nomChefEquipe;
                string codeProj = selectedEquipe.CasTest.First().codeProjet;
                lblProjetEquipe.Text = CtrlProjet.getNomProjet(codeProj);
                rtbCommentaire.Text = selectedEquipe.descEquipe;
                lstTesteurEquipe.Items.Clear();
                foreach (Employe emp in selectedEquipe.Employe1)
	            {
                    lstTesteurEquipe.Items.Add(emp.prenomEmploye+" "+emp.nomEmploye);
	            }
            }
            else if (cmbFiltre.Text == "Jeu")
            {
                string nomJeu = dgvResultats.SelectedRows[0].Cells[0].Value.ToString();
                cJeu jeu = CtrlJeu.GetJeu(nomJeu);
                lblNoJeu.Text = jeu.idJeu.ToString();
                lblNomJeu.Text = jeu.nomJeu;
                lblDevJeu.Text = jeu.developeur;
                lblClassJeu.Text = jeu.ClassificationJeu.nomClassification;
                rtbDescription.Text = jeu.descJeu;
                rtbConfiguration.Text = jeu.configMinimal;
                lstBoxVersion.Items.Clear();
                foreach (VersionJeu version in jeu.VersionJeu)
                {
                    lstBoxVersion.Items.Add(version.nomVersionJeu);
                }
                lstBoxPlat1.Items.Clear();
                foreach (Plateforme plat in jeu.Plateforme)
                {
                    lstBoxPlat1.Items.Add(plat.nomPlateforme);
                }
                lstBoxTheme1.Items.Clear();
                foreach (ThemeJeu theme in jeu.ThemeJeu)
                {
                    lstBoxTheme1.Items.Add(theme.nomTheme);
                }
                lstBoxGenre1.Items.Clear();
                foreach (GenreJeu genre in jeu.GenreJeu)
                {
                    lstBoxGenre1.Items.Add(genre.nomGenre);
                }
            }
            else if (cmbFiltre.Text == "Plateforme")
            {
                string nomPlat = dgvResultats.SelectedRows[0].Cells[1].Value.ToString();
                Plateforme plat = CtrlPlateforme.GetPlateforme(nomPlat);
                lblNoPlate.Text = plat.idPlateforme.ToString();
                lblTypePlate.Text = plat.TypePlateforme.nomTypePlateforme;
                lblNomPlate.Text = plat.nomPlateforme;
                rtxtConfigPlate.Text = plat.configPlateforme;
                rtxtCommPlate.Text = plat.commPlateforme;
            }
        }

        // lorsqu'un élément dans la liste  est sélectionné, on affiche ses infos dans la tab 
        private void AfficherInfoTab()
        {

        }

        private void cmbFiltre_DropDown(object sender, EventArgs e)
        {
            cmbFiltre.Items.Clear();
            if(lstDroits.Contains(15)||lstDroits.Contains(16))
            {
                cmbFiltre.Items.Add("Employé");
            }
            if(lstDroits.Contains(17)||lstDroits.Contains(18))
            {
                cmbFiltre.Items.Add("Équipe");
            }
            if(lstDroits.Contains(7)||lstDroits.Contains(8))
            {
                cmbFiltre.Items.Add("Jeu");
            }
            if(lstDroits.Contains(13)||lstDroits.Contains(14))
            {
                cmbFiltre.Items.Add("Plateforme");
            }
            if(lstDroits.Contains(1)||lstDroits.Contains(2))
            {
                cmbFiltre.Items.Add("Système d'exploitation");
            }
            if(cmbFiltre.Items.Count == 0)
            {
                messageDroits();
            }
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void btnModifierEmp_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(16))
            {
                if (cmbFiltre.Text == "Employé")
                {
                    string nomPren;
                    nomPren = dgvResultats.SelectedRows[0].Cells[0].Value.ToString() + " " + dgvResultats.SelectedRows[0].Cells[1].Value.ToString();
                    Employe emp = CtrlEmploye.emp(nomPren);
                    frmAjouterEmploye frmEmp = new frmAjouterEmploye(emp.nomEmploye, emp.prenomEmploye, emp.adressePostale, emp.numTelPrincipal, emp.numTelSecondaire, emp.dateEmbauche, CtrlTypeTest.lstTypeTestAssEmp(emp), emp.competenceParticuliere, emp);
                    frmEmp.ShowDialog();
                    //dgvResultats.Rows.Clear();
                }
            }
            else
            {
                messageDroits();
            }
        }

        private void btnModifierEquipe_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(18))
            {
                if (cmbFiltre.Text == "Équipe")
                {
                    //Equipe equipe = CtrlEquipe.getSelectedEquipe() Probleme ID si en ordre croissant
                }
            }
            else
            {
                messageDroits();
            }
        }

        private void btnModifierJeu_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(8))
            {
                if (cmbFiltre.Text == "Jeu")
                {
                    cJeu jeu = CtrlJeu.GetJeu(lblNomJeu.Text);
                    frmJeu frmJeu = new Jeu.frmJeu(jeu);
                    frmJeu.ShowDialog();
                    //dgvResultats.Rows.Clear();
                }
            }
            else
            {
                messageDroits();
            }
        }

        private void btnModifierPlateforme_Click(object sender, EventArgs e)
        {
            if (lstDroits.Contains(10))
            {
                if (cmbFiltre.Text == "Plateforme")
                {
                    Plateforme plat = CtrlPlateforme.GetPlateforme(lblNomPlate.Text);
                    frmPlateforme frmPlat = new frmPlateforme(plat);
                    frmPlat.ShowDialog();
                    //dgvResultats.Rows.Clear();
                }
            }
            else
            {
                messageDroits();
            }
        }

    

        

    }
}
