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
using Texcel.Interfaces.Test;

namespace Texcel.Interfaces
{
    public partial class frmAdmin : frmForm
    {
        private List<int> lstDroits;
        
        // Contructeur de la form
        public frmAdmin()
        {
            InitializeComponent();
        }

        // S'execute lorsque la form est rendu visible ou invisible
        // Recupère la liste des droits de l'utilisateur connecté et rend invisible les pages
        // qu'il n'a pas accès dans le menu
        private void frmAdmin_VisibleChanged(object sender, EventArgs e)
        {
            if (CtrlController.GetCurrentUser() != null)
            {
                foreach (Groupe groupe in CtrlController.GetCurrentUser().Groupe)
                {
                    lstDroits = CtrlController.GetDroits(groupe);
                    if (!lstDroits.Contains(2))
                    {
                        this.smiSysExp.Visible = false;
                        this.btnModifierSysExp.Visible = false;
                    }
                    if (!lstDroits.Contains(10))
                    {
                        this.smiTypePlateforme.Visible = false;
                    }
                    if (!lstDroits.Contains(14))
                    {
                        this.smiPlateforme.Visible = false;
                        this.btnModifierPlateforme.Visible = false;
                    }
                    if (!lstDroits.Contains(12))
                    {
                        this.smiTheme.Visible = false;
                    }
                    if (!lstDroits.Contains(6))
                    {
                        this.smiGenre.Visible = false;
                    }
                    if (!lstDroits.Contains(4))
                    {
                        this.smiClassification.Visible = false;
                    }
                    if (!lstDroits.Contains(8))
                    {
                        this.smiJeu.Visible = false;
                        this.btnModifierJeu.Visible = false;
                        this.smiVersionJeu.Visible = false;
                    }
                    if (!lstDroits.Contains(16))
                    {
                        this.btnModifierEmp.Visible = false;
                    }
                    if (!lstDroits.Contains(18))
                    {
                        this.smiEquipe.Visible = false;
                        this.btnModifierEquipe.Visible = false;
                    }
                    if (!lstDroits.Contains(26))
                    {
                        this.smiGestionTest.Visible = false;
                    }
                    if (!lstDroits.Contains(16) && !lstDroits.Contains(18))
                    {
                        this.smiGestionPersonnel.Visible = false;
                    }
                    if (!lstDroits.Contains(2) && !lstDroits.Contains(4) && !lstDroits.Contains(6) && !lstDroits.Contains(8) && !lstDroits.Contains(10) && !lstDroits.Contains(12) &&  !lstDroits.Contains(14))
                    {
                        this.smiGestionJeu.Visible = false;
                    }
                    if (groupe.idGroupe == 1)
                    {
                        cmbFiltre.Text = "Employé";
                        btnRechercher_Click(this, null);
                    }
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
                        //Verification du fichier RH
                        cmbFiltre.Text = "Jeu";
                        btnRechercher_Click(this, null);
                        tabControl1.SelectedIndex = 2;
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
        }

        // Lance la recherche en fonction du filtre sélectionné
        private void btnRechercher_Click(object sender, EventArgs e)
        {
            clearTabControl();
            ChoixFiltre(cmbFiltre.Text);
            dgvResultats_Click(this, null);
        }

        // Pour déterminer et afficher la liste d'éléments selon le filtre choisi
        private void ChoixFiltre(string _nomFiltre)
        {
            int n = 0;
            string cle = txtRechercher.Text.ToLower();
            dgvResultats.Columns.Clear();

            switch (_nomFiltre)
            {
                case "Plateforme":
                    dgvResultats.Columns.Add("0", "Type de plateforme");
                    dgvResultats.Columns.Add("1", "Plateforme");
                    tabControl1.SelectedIndex = 3;
                    foreach (AllPlateforme plat in CtrlAdmin.GetAllPlateformeView())
                    {
                        if (cle == "" || plat.tagPlateforme.ToLower().Contains(cle))
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
                        if (cle == "" || sysexp.tagSysExp.ToLower().Contains(cle))
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
                        if (cle == "" || jeu.tagJeu.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Value = jeu.nomJeu;
                            dgvResultats.Rows[n].Cells[1].Value = jeu.developeur;
                            n++;
                        }
                    }
                    break;

                case "Équipe":
                    dgvResultats.Columns.Add("0", "ID");
                    dgvResultats.Columns.Add("1", "Équipe");
                    dgvResultats.Columns.Add("2", "Chef d'équipe");
                    tabControl1.SelectedIndex = 1;
                    foreach (AllEquipe equipe in CtrlAdmin.GetAllEquipeView())
                    {
                        if (cle == "" || equipe.tagEquipe.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Value = equipe.idEquipe;
                            dgvResultats.Rows[n].Cells[1].Value = equipe.nomEquipe;
                            dgvResultats.Rows[n].Cells[2].Value = equipe.ChefEquipe;
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
                        if (cle == "" || employe.tagEmploye.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Value = employe.nomEmploye;
                            dgvResultats.Rows[n].Cells[1].Value = employe.prenomEmploye;
                            n++;
                        }
                    }
                    break;

                case "Projet":
                    dgvResultats.Columns.Add("0", "Code");
                    dgvResultats.Columns.Add("1", "Nom");
                    dgvResultats.Columns.Add("2", "Chef de projet");
                    dgvResultats.Columns.Add("3", "Jeu");
                    foreach (AllProjet projet in CtrlAdmin.GetAllProjetView())
                    {
                        if(cle == "" || projet.tagProjet.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Value = projet.codeProjet;
                            dgvResultats.Rows[n].Cells[1].Value = projet.nomProjet;
                            dgvResultats.Rows[n].Cells[2].Value = projet.chefProjet;
                            dgvResultats.Rows[n].Cells[3].Value = projet.nomJeu;
                            n++;
                        }
                    }
                    break;

                case "Cas de test":
                    dgvResultats.Columns.Add("0", "Code");
                    dgvResultats.Columns.Add("1", "Nom");
                    dgvResultats.Columns.Add("2", "Projet");
                    dgvResultats.Columns.Add("3", "Type de test");
                    foreach (AllCasTest casTest in CtrlAdmin.GetAllCasTestView())
                    {
                        if(cle == "" || casTest.tagCasTest.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Value = casTest.codeCasTest;
                            dgvResultats.Rows[n].Cells[1].Value = casTest.nomCasTest;
                            dgvResultats.Rows[n].Cells[2].Value = casTest.nomProjet;
                            dgvResultats.Rows[n].Cells[3].Value = casTest.nomTest;
                            n++;
                        }
                    }
                    break;

                default : 
                    MessageBox.Show("Veuillez sélectionner un filtre.", "Erreur",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    break;
            }
            this.dgvResultats_Click(this, null);
        }

        // Message d'erreur si l'utilisateur n'a pas accès à la section demandé
        private void messageDroits()
        {
            MessageBox.Show("Vous ne possédez pas les droits requis pour accéder à cette section. Contactez votre administrateur pour plus de détails. ", "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Cette section renforce tous les actions fait à partir du menu
        #region liensMenu
        private void smiSysExp_Click(object sender, EventArgs e)
        {
                frmAjouterSysExp frmSysExp = new frmAjouterSysExp();
                frmSysExp.ShowDialog();
        }

        private void smiTypePlateforme_Click(object sender, EventArgs e)
        {
                frmTypePlateforme frmTypePlateforme = new frmTypePlateforme();
                frmTypePlateforme.ShowDialog();
        }

        private void smiPlateforme_Click(object sender, EventArgs e)
        {
                frmPlateforme frmPlateforme = new frmPlateforme();
                frmPlateforme.ShowDialog();
        }

        private void smiTheme_Click(object sender, EventArgs e)
        {
                frmTheme frmTheme = new frmTheme();
                frmTheme.ShowDialog();
        }

        private void smiGenre_Click(object sender, EventArgs e)
        {
                frmGenre frmGenre = new frmGenre();
                frmGenre.ShowDialog();
        }

        private void smiClassification_Click(object sender, EventArgs e)
        {
                frmClassification frmClassification = new frmClassification();
                frmClassification.ShowDialog();
        }

        private void smiJeu_Click(object sender, EventArgs e)
        {
            frmJeu frmJeu = new frmJeu();
            frmJeu.ShowDialog();
        }

        private void smiEquipe_Click(object sender, EventArgs e)
        {
            frmCreerEquipe frmCreerEquipe = new frmCreerEquipe();
            frmCreerEquipe.ShowDialog();
        }

        private void smiTypeTest_Click(object sender, EventArgs e)
        {
            frmTypeTest frmTypeTest = new frmTypeTest();
            frmTypeTest.ShowDialog();
        }

        private void smiVersionJeu_Click(object sender, EventArgs e)
        {
            frmAjouterVersionJeu AjouterVersionJeu = new frmAjouterVersionJeu();
            AjouterVersionJeu.ShowDialog();
        }

        private void smiDeconnection_Click(object sender, EventArgs e)
        {
            CtrlAdmin.SetCurrentUser(null);
            this.Visible = false;
            frmLogin maFrmlogin = new frmLogin();
            maFrmlogin.ShowDialog();
        }

        private void smiQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        // S'execute lorsque l'utilisateur change le filtre
        // Slectionnne le bon tabControl en fonction du filtre choisi
        private void cmbFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvResultats.Columns.Clear();
            clearTabControl();
            switch (cmbFiltre.Text)
            {
                case "Employé": tabControl1.SelectedIndex = 0;
                    break;
                case "Équipe": tabControl1.SelectedIndex = 1;
                    break;
                case "Jeu": tabControl1.SelectedIndex = 2;
                    break;
                case "Plateforme": tabControl1.SelectedIndex = 3;
                    break;
                case "Système d'exploitation": tabControl1.SelectedIndex = 4;
                    break;
                case "Projet": tabControl1.SelectedIndex = 5;
                    break;
                case "Cas de test": tabControl1.SelectedIndex = 6;
                    break;
                default: tabControl1.SelectedIndex = 0;
                    break;
            }
            txtRechercher.Focus();
            txtRechercher.SelectAll();
        }

        // Affiche le tabControl ainsi que l'information de l'élément sélectionné
        private void dgvResultats_Click(object sender, EventArgs e)
        {
            if (dgvResultats.Rows.Count != 0)
            {
                int num = dgvResultats.CurrentCell.RowIndex;
                if (cmbFiltre.Text == "Employé")
                {   
                    string nomPren;
                    nomPren = dgvResultats[0, num].Value.ToString() + " " + dgvResultats[1, num].Value.ToString();
                    Employe emp = CtrlEmploye.emp(nomPren);
                    lblNoEmp.Text = emp.noEmploye.ToString();
                    lblNomEmp.Text = emp.nomEmploye;
                    lblPrenEmp.Text = emp.prenomEmploye;
                    lblAdresseEmp.Text = emp.adressePostale;
                    lblTelPrimEmp.Text = emp.numTelPrincipal;
                    lblTelSecEmp.Text = emp.numTelSecondaire;
                    dtpDateEmbauche.Value = emp.dateEmbauche;
                    lsbEmpComptesUtilisateur.Items.Clear();
                    lstBoxTypeTest.Items.Clear();
                    foreach (TypeTest tT in CtrlTypeTest.lstTypeTestAssEmp(emp))
                    {
                        lstBoxTypeTest.Items.Add(tT.nomTest);
                    }

                    foreach (Utilisateur uti in CtrlUtilisateur.lstUtilisateurAssocEmp(emp))
                    {
                        lsbEmpComptesUtilisateur.Items.Add(uti.nomUtilisateur);
                    }
                    richTextBox1.Text = emp.competenceParticuliere;
                }
                else if (cmbFiltre.Text == "Équipe")
                {
                    string nomChefEquipe = dgvResultats[2, num].Value.ToString();
                    int id = Convert.ToInt16(dgvResultats[0, num].Value);
                    Equipe selectedEquipe = CtrlEquipe.getEquipeById(id);
                    lblNomEquipe.Text = selectedEquipe.nomEquipe;
                    lblChefEquipe.Text = nomChefEquipe;
                    string codeProj = selectedEquipe.codeProjet;
                    if (codeProj != null)
                    {
                        lblProjetEquipe.Text = CtrlProjet.getNomProjet(codeProj);
                    }
                    else
                    {
                        lblProjetEquipe.Text = "Aucun";
                    }
                    rtbCommentaire.Text = selectedEquipe.descEquipe;
                    lstTesteurEquipe.Items.Clear();
                    foreach (Employe emp in selectedEquipe.Employe1)
                    {
                        lstTesteurEquipe.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
                    }
                }
                else if (cmbFiltre.Text == "Jeu")
                {
                    string nomJeu = dgvResultats[0, num].Value.ToString();
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
                    string nomPlat = dgvResultats[1, num].Value.ToString();
                    Plateforme plat = CtrlPlateforme.GetPlateforme(nomPlat);
                    lblNoPlate.Text = plat.idPlateforme.ToString();
                    lblTypePlate.Text = plat.TypePlateforme.nomTypePlateforme;
                    lblNomPlate.Text = plat.nomPlateforme;
                    rtxtConfigPlate.Text = plat.configPlateforme;
                    rtxtCommPlate.Text = plat.commPlateforme;
                }
                else if (cmbFiltre.Text == "Système d'exploitation")
                {
                    string nomSysExp = dgvResultats[0, num].Value.ToString();
                    string editionSysExp = dgvResultats[2, num].Value.ToString();
                    string versionSysExp = dgvResultats[3, num].Value.ToString(); 
                    SysExp sE = CtrlSysExp.GetSysExp(nomSysExp);
                    EditionSysExp eSE = CtrlEditionSysExp.GetEditionSysExp(editionSysExp, sE.idSysExp);
                    VersionSysExp vSE = CtrlVersionSysExp.GetVersionSysExp(eSE.idEdition, versionSysExp);
                    noSE.Text = sE.idSysExp.ToString();
                    nomSE.Text = sE.nomSysExp;
                    lblEdSE.Text = editionSysExp;
                    versionSE.Text = versionSysExp;
                    codeSE.Text = sE.codeSysExp;
                    rtbCommSysExp.Text = vSE.commSysExp;
                }
                else if (cmbFiltre.Text == "Projet")
                {
                    string nomProjet = dgvResultats[1, num].Value.ToString();
                    cProjet projet = CtrlProjet.getProjet(nomProjet);

                    txtCode.Text = projet.codeProjet;
                    txtNom.Text = projet.nomProjet;
                    Employe chefProjet = CtrlEmploye.getEmployeByNo(projet.chefProjet);
                    txtChefProjet.Text = chefProjet.nomEmploye + ", " + chefProjet.prenomEmploye;
                    txtDateCreation.Text = Convert.ToString(projet.dateCreation);
                    txtDateLivraison.Text = Convert.ToString(projet.dateLivraison);
                    txtJeu.Text = projet.VersionJeu.cJeu.nomJeu;
                    txtVersionJeu.Text = projet.VersionJeu.nomVersionJeu;
                    rtbDescription.Text = projet.descProjet;
                    rtbObj.Text = projet.objProjet;
                    rtbDiv.Text = projet.divProjet;
                }
                else if (cmbFiltre.Text == "Cas de test")
                {
                    string nomCasTest = dgvResultats[1, num].Value.ToString();
                    CasTest casTest = CtrlCasTest.getCasTest(nomCasTest);

                    txtCodeCT.Text = casTest.codeCasTest;
                    txtNomCT.Text = casTest.nomCasTest;
                    txtProjet.Text = casTest.cProjet.nomProjet;
                    txtDifficulte.Text = casTest.Difficulte.nomDiff;
                    txtPriorite.Text = casTest.NiveauPriorite.nomNivPri;
                    txtDateCreationCT.Text = Convert.ToString(casTest.dateCreation);
                    txtDateLivraisonCT.Text = Convert.ToString(casTest.dateLivraison);
                    txtTypeTest.Text = casTest.TypeTest.nomTest;
                    rtbDescCT.Text = casTest.descCasTest;
                }
            }
            else
            {
                clearTabControl();
            }
        }

        // Permet d'afficher seulement les filtres autorisés en fonction de l'utilisateur connecté
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
            if (lstDroits.Contains(19))
            {
                cmbFiltre.Items.Add("Projet"); 
            }
            if (lstDroits.Contains(20))
            {
                cmbFiltre.Items.Add("Cas de test"); 
            }
            if(cmbFiltre.Items.Count == 0)
            {
                messageDroits();
            }
        }

        // Ouvre la fenêtre de login lors de l'ouverture de cette form
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        // Permet de modifier l'employé selectionné dans le dataGrid
        private void btnModifierEmp_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Employé")
            {
                int selectedRow = dgvResultats.CurrentCell.RowIndex;
                string nomPren;
                nomPren = dgvResultats[0, selectedRow].Value.ToString() + " " + dgvResultats[1, selectedRow].Value.ToString();
                Employe emp = CtrlEmploye.emp(nomPren);
                frmAjouterEmploye frmEmp = new frmAjouterEmploye(emp,0);
                frmEmp.ShowDialog();
                ChoixFiltre("Employé");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[selectedRow].Selected = true;
                dgvResultats_Click(this, null);
            }
        }

        // Permet de modifier l'équipe selectionné dans le dataGrid
        private void btnModifierEquipe_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Équipe")
            {
                int selectedRow = dgvResultats.CurrentCell.RowIndex;
                Equipe equipe = CtrlEquipe.getEquipeById(Convert.ToInt16(dgvResultats[0, selectedRow].Value));
                frmCreerEquipe frmEquipe = new frmCreerEquipe(equipe);
                frmEquipe.ShowDialog();
                CtrlAdmin.refreshEntity();
                ChoixFiltre("Équipe");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[selectedRow].Selected = true;
                dgvResultats_Click(this, null);
            }
        }

        // Permet de modifier le jeu selectionné dans le dataGrid
        private void btnModifierJeu_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Jeu")
            {
                int selectedRow = dgvResultats.CurrentCell.RowIndex;
                cJeu jeu = CtrlJeu.GetJeu(lblNomJeu.Text);
                frmJeu frmJeu = new Jeu.frmJeu(jeu);
                frmJeu.ShowDialog();
                ChoixFiltre("Jeu");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[selectedRow].Selected = true;
                dgvResultats_Click(this, null);
            }
        }

        // Permet de modifier la plateforme selectionné dans le dataGrid
        private void btnModifierPlateforme_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Plateforme")
            {
                int selectedRow = dgvResultats.CurrentCell.RowIndex;
                Plateforme plat = CtrlPlateforme.GetPlateforme(lblNomPlate.Text);
                frmPlateforme frmPlat = new frmPlateforme(plat);
                frmPlat.ShowDialog();
                ChoixFiltre("Plateforme");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[selectedRow].Selected = true;
                dgvResultats_Click(this, null);
            }
        }

        // Permet de modifier le systeme d'exploitation selectionné dans le dataGrid
        private void btnModifierSysExp_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Système d'exploitation")
            {
                int num = dgvResultats.CurrentCell.RowIndex;
                string nomSysExp = dgvResultats[0, num].Value.ToString();
                string editionSysExp = dgvResultats[2, num].Value.ToString();
                string versionSysExp = dgvResultats[3, num].Value.ToString();
                SysExp sE = CtrlSysExp.GetSysExp(nomSysExp);
                EditionSysExp eSE = CtrlEditionSysExp.GetEditionSysExp(editionSysExp, sE.idSysExp);
                VersionSysExp vSE = CtrlVersionSysExp.GetVersionSysExp(eSE.idEdition, versionSysExp);
                
                frmAjouterSysExp frmSysExp = new frmAjouterSysExp(sE,eSE,vSE);
                frmSysExp.ShowDialog();
                ChoixFiltre("Système d'exploitation");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[num].Selected = true;
                dgvResultats_Click(this, null);
            }
        }
        
        // Efface tous les champs de tous les tabControls
        private void clearTabControl()
        {
            clearTabControlEmploye();
            clearTabControlEquipe();
            clearTabControlJeu();
            clearTabControlPlateforme();
            clearTabControlSysExp();
            clearTabControlProjet();
            clearTabControlCasTest();
        }

        // Efface tous les champs du tabControl Employe
        private void clearTabControlEmploye()
        {
            lblNoEmp.Text = "";
            lblNomEmp.Text = "";
            lblPrenEmp.Text = "";
            lblAdresseEmp.Text = "";
            lblTelPrimEmp.Text = "";
            lblTelSecEmp.Text = "";
            dtpDateEmbauche.Value = DateTime.Today.AddYears(-100);
            lsbEmpComptesUtilisateur.Items.Clear();
            lstBoxTypeTest.Items.Clear();
            richTextBox1.Text = "";
        }

        // Efface tous les champs du tabControl Equipe
        private void clearTabControlEquipe()
        {
            lblNomEquipe.Text = "";
            lblChefEquipe.Text = "";
            lblProjetEquipe.Text = "";
            rtbCommentaire.Text = "";
            lstTesteurEquipe.Items.Clear();
        }

        // Efface tous les champs du tabControl Jeu
        private void clearTabControlJeu()
        {
            lblNoJeu.Text = "";
            lblNomJeu.Text = "";
            lblDevJeu.Text = "";
            lblClassJeu.Text = "";
            rtbDescription.Text = "";
            rtbConfiguration.Text = "";
            lstBoxVersion.Items.Clear();
            lstBoxPlat1.Items.Clear();
            lstBoxTheme1.Items.Clear();
            lstBoxGenre1.Items.Clear();
        }

        // Efface tous les champs du tabControl Plateforme
        private void clearTabControlPlateforme()
        {
            lblNoPlate.Text = "";
            lblTypePlate.Text = "";
            lblNomPlate.Text = "";
            rtxtConfigPlate.Text = "";
            rtxtCommPlate.Text = "";
        }
        
        // Efface tous les champs du tabControl Système d'exploitation
        private void clearTabControlSysExp()
        {
            noSE.Text = "";
            nomSE.Text = "";
            lblEdSE.Text = "";
            codeSE.Text = "";
            versionSE.Text = "";
            rtbCommSysExp.Text = "";
        }

        // Efface tous les champs du tabControl Projet
        private void clearTabControlProjet()
        {
            txtCode.Text = "";
            txtNom.Text = "";
            txtChefProjet.Text = "";
            txtDateCreation.Text = "";
            txtDateLivraison.Text = "";
            txtJeu.Text = "";
            txtVersionJeu.Text = "";
            rtbDescription.Text = "";
            rtbObj.Text = "";
            rtbDiv.Text = "";
        }

        // Efface tous les champs du tabControl CasTest
        private void clearTabControlCasTest()
        {
            txtCodeCT.Text = "";
            txtNomCT.Text = "";
            txtProjet.Text = "";
            txtDifficulte.Text = "";
            txtPriorite.Text = "";
            txtDateCreationCT.Text = "";
            txtDateLivraisonCT.Text = "";
            txtTypeTest.Text = "";
            rtbDescCT.Text = "";
        }

        // Permet à l'utilisateur de sélectionner un champ dans le dataGrid avec le bouton droit de la souris
        private void dgvResultats_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvResultats.ClearSelection();
                dgvResultats[e.ColumnIndex, e.RowIndex].Selected = true;
            }
        } 

        // Sélectionne tout le contenu du champ recherche lorsque l'utilisateur clique sur le champ
        private void txtRechercher_Enter(object sender, EventArgs e)
        {
            txtRechercher.SelectAll();
        }
    }
}
