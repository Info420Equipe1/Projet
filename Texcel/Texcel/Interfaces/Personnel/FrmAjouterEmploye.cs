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
using Texcel.Classes.Test;
using Texcel.Classes;

namespace Texcel.Interfaces.Personnel
{
    
    public partial class frmAjouterEmploye : frmForm
    {
        bool modifier = false;
        Employe employe = new Employe();

        //Mode creer employé
        public frmAjouterEmploye()
        {
            InitializeComponent();
            CtrlTypeTest.PopulateLstTypeTest();
            AfficherLstBox();
            lstBoxCompteUti.Visible = false;
            label2.Visible = false;
            btnCreerUti.Visible = false;
      
        }

        public frmAjouterEmploye(Employe _employe)
        {
            InitializeComponent();
            CtrlTypeTest.PopulateLstTypeTest();
            AfficherLstBox();
            AfficherEmploye(_employe);

            
        }

        private void AfficherEmploye(Employe _employe)
        {
            txtNumeroEmp.Text = _employe.noEmploye.ToString();   
            txtNom.Text = _employe.nomEmploye;
            txtPrenom.Text = _employe.prenomEmploye;
            txtAdresse.Text = _employe.adressePostale;
            txtTelPrim.Text = _employe.numTelPrincipal;
            txtTelSec.Text = _employe.numTelSecondaire;
            dateTPEmp.Value = _employe.dateEmbauche;
            rtbCompParticuliere.Text = _employe.competenceParticuliere;

            
        }

        //Mode modifier (Arrive de la fenetre recherche)
        public frmAjouterEmploye(Employe _employe, int _parRapport)
        {
            InitializeComponent();
            txtNumeroEmp.Text = _employe.noEmploye.ToString();
            txtNom.Text = _employe.nomEmploye;
            txtPrenom.Text = _employe.prenomEmploye;
            txtAdresse.Text = _employe.adressePostale;
            txtTelPrim.Text = _employe.numTelPrincipal;
            txtTelSec.Text = _employe.numTelSecondaire;
            dateTPEmp.Value = _employe.dateEmbauche;
            rtbCompParticuliere.Text = _employe.competenceParticuliere;

            CtrlTypeTest.PopulateLstTypeTest(_employe);
            AfficherLstBox();
            //RemplirListBoxPourModeModif(_emp);
            remplirListBoxUtil(_employe);
            modifier = true;
            employe = CtrlEmploye.emp(_employe.nomEmploye + " " + _employe.prenomEmploye);
            btnEnregistrer.Text = "Modifier";
            this.Text = "Modifier employée";
         
        }

        private void RemplirListBoxPourModeModif(Employe _emp)
        {
            foreach (TypeTest typTest in CtrlTypeTest.lstTypeTestAssEmp(_emp))
            {
                lstBoxTypeTestEmp.Items.Add(typTest.nomTest);
                
            }
        }

        // Remplir les lstBox
        private void AfficherLstBox()
        {
            lstBoxTypeTest.Items.Clear();
            lstBoxTypeTestEmp.Items.Clear();
        
            //Emplissage de la list box des TypeTest 
            foreach (KeyValuePair<TypeTest, int> tT in CtrlTypeTest.getlstTypeTestLstBox)
            {
                if (tT.Value == 0)
                {
                    lstBoxTypeTest.Items.Add(tT.Key.nomTest); 
                }
                else
                {
                    lstBoxTypeTestEmp.Items.Add(tT.Key.nomTest);
                }

            }
        }

        // Afficher les comptes utilisateurs à  l'employé
        private void remplirListBoxUtil(Employe _emp)
        {
            lstBoxCompteUti.Items.Clear();
            foreach (Utilisateur uti in CtrlUtilisateur.lstUtilisateurAssocEmp(_emp))
            {
                lstBoxCompteUti.Items.Add(uti.nomUtilisateur);
            }
        }
      
        

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if ((txtAdresse.Text == "") || (txtNom.Text == "") || (txtPrenom.Text == "") || (txtNom.Text == ""))
            {
                MessageBox.Show("Certain champs ne sont pas rempli");
                return;
            }
            if (modifier == false)
            {
                string message;
                message = CtrlEmploye.Ajouter(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtAdresse.Text, txtTelPrim.Text.Trim(), txtTelSec.Text.Trim(), rtbCompParticuliere.Text, dateTPEmp.Value);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                string message;
                message = CtrlEmploye.Modifier(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtAdresse.Text, txtTelPrim.Text.Trim(), txtTelSec.Text.Trim(), rtbCompParticuliere.Text, dateTPEmp.Value, employe);
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnModifUti.Visible = true;
        }

        private void btnModifUti_Click(object sender, EventArgs e)
        {
            if (lstBoxCompteUti.SelectedItem != null)
            {
                Utilisateur uti = CtrlUtilisateur.getUtilisateur(lstBoxCompteUti.SelectedItem.ToString());
                frmUtilisateur frmUti = new frmUtilisateur(uti.nomUtilisateur, uti.motPasse, CtrlUtilisateur.lstGrAssUtil(uti), CtrlEmploye.emp(txtNom.Text + " " + txtPrenom.Text), this);
                frmUti.ShowDialog();          
            }
            else
            {
                CtrlController.MessageErreur("Vous devez choisir un compte!");
            }
            
        }

        private void btnCreerUti_Click(object sender, EventArgs e)
        {
            frmUtilisateur frmUti = new frmUtilisateur(CtrlEmploye.emp(txtNom.Text + " " + txtPrenom.Text), this);           
            frmUti.ShowDialog();
        }

        private void btnFlecheAjouter_Click(object sender, EventArgs e)
        {
            if ((lstBoxTypeTest.Items.Count == 0) || (lstBoxTypeTest.SelectedIndex == -1) || (lstBoxTypeTest.SelectedItems.Count > 1))
            {
                string ad = "Veuillez selectionner un type de test à ajouter.";
                CtrlController.MessageErreur(ad);
            }
            else
            {
                CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(lstBoxTypeTest.Text), true);
                AfficherLstBox();
            }
        }

        private void bntFlecheRetirer_Click(object sender, EventArgs e)
        {
            if ((lstBoxTypeTestEmp.Items.Count == 0) || (lstBoxTypeTestEmp.SelectedIndex == -1) || (lstBoxTypeTestEmp.SelectedItems.Count > 1))
            {
                string ad = "Veuillez selectionner une type de test à retirer à l'employé.";
                CtrlController.MessageErreur(ad);
            }
            else
            {
                CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(lstBoxTypeTestEmp.Text), false);
                AfficherLstBox();
            }
        }
        private void btnFlecheAjouterMultiple_Click(object sender, EventArgs e)
        {
            if ((lstBoxTypeTest.Items.Count == 0))
            {
                string ad = "Veuillez selectionner un type de test à ajouter.";
                CtrlController.MessageErreur(ad);
            }
            else if (lstBoxTypeTest.SelectedIndex == -1)
            {
                foreach (string item in lstBoxTypeTest.Items)
                {
                    CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(item), true);
                }
                AfficherLstBox();
            }
            else
            {
                foreach (string item in lstBoxTypeTest.SelectedItems)
                {
                    CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(item), true);
                }
                AfficherLstBox();
            }
        }

        private void bntFlecheRetirerMultiple_Click(object sender, EventArgs e)
        {
            if ((lstBoxTypeTestEmp.Items.Count == 0))
            {
                string ad = "Veuillez selectionner une type de test à retirer à l'employé.";
                CtrlController.MessageErreur(ad);
            }
            else if ((lstBoxTypeTestEmp.SelectedIndex == -1))
            {
                foreach (string item in lstBoxTypeTestEmp.Items)
                {
                    CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(item), false);
                }
                AfficherLstBox();
            }
            else
            {
                foreach (string item in lstBoxTypeTestEmp.SelectedItems)
                {
                    CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(item), false);
                }
                AfficherLstBox();
            }
        }

        public void ActualiserLstCompte()
        {            
            remplirListBoxUtil(employe);
        }



    }
}
