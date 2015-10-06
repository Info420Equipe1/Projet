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
            if (cmbFiltre.Text != "")
            {
                switch (cmbFiltre.Text)
                {
                    case "Plateforme":
                        foreach (AllPlateforme Plat in CtrlAdmin.GetAllPlateformeView())
                        {
                            lsbResultats.Items.Add(Plat.nomPlateforme);
                        }
                        break;

                    case "Système d'exploitation":
                        foreach (AllSysExp SysExp in CtrlAdmin.GetAllSysExpView())
                        {
                            lsbResultats.Items.Add(SysExp.nomSysExp);
                        }
                        break;

                    /*case "Jeu":
                        foreach (AllJeu Jeu in CtrlAdmin.GetAllJeuView())
                        {
                            lsbResultats.Items.Add(Jeu.nomJeu);
                        }
                        break;

                    case "Équipe":
                        foreach (AllEquipe Equipe in CtrlAdmin.GetAllEquipeView())
                        {
                            lsbResultats.Items.Add(Equipe.nomEquipe);
                        }
                        break;

                    case "Employé":
                        foreach (AllEmploye Employe in CtrlAdmin.GetAllEmployeView())
                        {
                            lsbResultats.Items.Add(Employe.nom + ", " + Employe.prenom);
                        }
                        break;*/
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
    }
}
