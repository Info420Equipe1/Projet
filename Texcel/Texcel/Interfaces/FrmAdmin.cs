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

        private void frmAdmin_VisibleChanged(object sender, EventArgs e)
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
                }
                if (!lstDroits.Contains(16))
                {
                    this.smiEmploye.Visible = false;
                    this.btnModifierEmp.Visible = false;
                }
                if (!lstDroits.Contains(18))
                {
                    this.smiEquipe.Visible = false;
                    this.btnModifierEquipe.Visible = false;
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
                    //MessageBox.Show("Un administrateur du système est connecté");
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
                    dgvResultats.Columns.Add("0", "ID");
                    dgvResultats.Columns.Add("1", "Équipe");
                    dgvResultats.Columns.Add("2", "Chef d'équipe");
                    tabControl1.SelectedIndex = 1;
                    foreach (AllEquipe equipe in CtrlAdmin.GetAllEquipeView())
                    {
                        if (cle == "" || equipe.nomEquipe.ToLower().Contains(cle) || equipe.ChefEquipe.ToLower().Contains(cle))
                        {
                            dgvResultats.Rows.Add();
                            dgvResultats.Rows[n].Cells[0].Tag = equipe.idEquipe;
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
            this.dgvResultats_Click(this, null);
        }

        private void messageDroits()
        {
            MessageBox.Show("Vous ne possédez pas les droits requis pour accéder à cette section. Contactez votre administrateur pour plus de détails. ", "Droits insuffisants", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                default: tabControl1.SelectedIndex = 0;
                    break;
            }
            txtRechercher.Focus();
            txtRechercher.SelectAll();
        }

        //Afficher les tab ainsi que l'information de l'élément sélectionné
        private void dgvResultats_Click(object sender, EventArgs e)
        {
            if (dgvResultats.Rows.Count != 0)
            {
                if (cmbFiltre.Text == "Employé")
                {
                    int num = dgvResultats.CurrentCell.RowIndex;
                    
                    string nomPren;
                    nomPren = dgvResultats[0, num].Value.ToString() + " " + dgvResultats[1, num].Value.ToString();
                    Employe emp = CtrlEmploye.emp(nomPren);
                    lblNoEmp.Text = emp.noEmploye.ToString();
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
                    int num = dgvResultats.CurrentCell.RowIndex;
                    string nomChefEquipe = dgvResultats[2, num].Value.ToString();
                    int id = Convert.ToInt16(dgvResultats[0, num].Tag);
                    Equipe selectedEquipe = CtrlEquipe.getSelectedEquipe(id);
                    lblNomEquipe.Text = selectedEquipe.nomEquipe;
                    lblChefEquipe.Text = nomChefEquipe;
                    string codeProj = selectedEquipe.CasTest.First().codeProjet;
                    lblProjetEquipe.Text = CtrlProjet.getNomProjet(codeProj);
                    rtbCommentaire.Text = selectedEquipe.descEquipe;
                    lstTesteurEquipe.Items.Clear();
                    foreach (Employe emp in selectedEquipe.Employe1)
                    {
                        lstTesteurEquipe.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
                    }
                }
                else if (cmbFiltre.Text == "Jeu")
                {
                    int num = dgvResultats.CurrentCell.RowIndex;
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
                    int num = dgvResultats.CurrentCell.RowIndex;
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
                    int num = dgvResultats.CurrentCell.RowIndex;
                    string nomSysExp = dgvResultats[0, num].Value.ToString();
                    string editionSysExp = dgvResultats[2, num].Value.ToString();
                    string versionSysExp = dgvResultats[3, num].Value.ToString();
                    SysExp sE = CtrlSysExp.GetSysExp(nomSysExp);
                    EditionSysExp eSE = CtrlEditionSysExp.GetEditionSysExp(editionSysExp, sE.idSysExp);
                    VersionSysExp vSE = CtrlVersionSysExp.GetVersionSysExp(eSE.idEdition, versionSysExp);

                    noSE.Text = sE.idSysExp.ToString();
                    nomSE.Text = sE.nomSysExp;
                    edSE.Text = editionSysExp;
                    versionSE.Text = versionSysExp;
                    codeSE.Text = sE.codeSysExp;
                    rtbCommSysExp.Text = vSE.commSysExp;
                } 
            }
            else
            {
                clearTabControl();
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
            if (cmbFiltre.Text == "Employé")
            {
                int selectedRow = dgvResultats.CurrentCell.RowIndex;
                string nomPren;
                nomPren = dgvResultats[0, selectedRow].Value.ToString() + " " + dgvResultats[1, selectedRow].Value.ToString();
                Employe emp = CtrlEmploye.emp(nomPren);
                frmAjouterEmploye frmEmp = new frmAjouterEmploye(emp.nomEmploye, emp.prenomEmploye, emp.adressePostale, emp.numTelPrincipal, emp.numTelSecondaire, emp.dateEmbauche, CtrlTypeTest.lstTypeTestAssEmp(emp), emp.competenceParticuliere, emp);
                frmEmp.ShowDialog();
                ChoixFiltre("Employé");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[selectedRow].Selected = true;
                dgvResultats_Click(this, null);
            }
        }

        private void btnModifierEquipe_Click(object sender, EventArgs e)
        {
            if (cmbFiltre.Text == "Équipe")
            {
                int selectedRow = dgvResultats.CurrentCell.RowIndex;
                Equipe equipe = CtrlEquipe.getSelectedEquipe(Convert.ToInt16(dgvResultats[0, selectedRow].Value));
                frmCreerEquipe frmEquipe = new frmCreerEquipe(equipe);
                frmEquipe.ShowDialog();
                CtrlAdmin.refreshEntity();
                ChoixFiltre("Équipe");
                dgvResultats.Rows[0].Selected = false;
                dgvResultats.Rows[selectedRow].Selected = true;
                dgvResultats_Click(this, null);
            }
        }

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
        
        private void clearTabControl()
        {
            clearTabControlEmploye();
            clearTabControlEquipe();
            clearTabControlJeu();
            clearTabControlPlateforme();
            clearTabControlSysExp();
        }
        private void clearTabControlEmploye()
        {
            lblNoEmp.Text = "";
            lblNomEmp.Text = "";
            lblPrenEmp.Text = "";
            lblAdresseEmp.Text = "";
            lblTelPrimEmp.Text = "";
            lblTelSecEmp.Text = "";
            dateTimePicker1.Value = DateTime.Today.AddYears(-100);
            listBox1.Items.Clear();
            lstBoxTypeTest.Items.Clear();
            richTextBox1.Text = "";
        }
        private void clearTabControlEquipe()
        {
            lblNomEquipe.Text = "";
            lblChefEquipe.Text = "";
            lblProjetEquipe.Text = "";
            rtbCommentaire.Text = "";
            lstTesteurEquipe.Items.Clear();
        }
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
        private void clearTabControlPlateforme()
        {
            lblNoPlate.Text = "";
            lblTypePlate.Text = "";
            lblNomPlate.Text = "";
            rtxtConfigPlate.Text = "";
            rtxtCommPlate.Text = "";
        }
        
        private void clearTabControlSysExp()
        {
            noSE.Text = "";
            nomSE.Text = "";
            edSE.Text = "";
            codeSE.Text = "";
            versionSE.Text = "";
            rtbCommSysExp.Text = "";
        }

        private void copierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(dgvResultats.SelectedCells[0].Value.ToString());
        }

        private void dgvResultats_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dgvResultats.ClearSelection();
                dgvResultats[e.ColumnIndex, e.RowIndex].Selected = true;
            }
        }

        private void txtRechercher_Enter(object sender, EventArgs e)
        {
            txtRechercher.SelectAll();
        }

    
      
       



       

    }
}
