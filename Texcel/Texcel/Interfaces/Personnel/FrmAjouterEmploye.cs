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
        }

        //Mode modifier (Arrive de la fenetre recherche)
        public frmAjouterEmploye(string _nom, string _pren, string _adresse, string _telPrim, string _telSec, DateTime _date, List<TypeTest> _lstTypeTest, string _compParti, Employe _emp)
        {
            InitializeComponent();
            txtNom.Text = _nom;
            txtPrenom.Text = _pren;
            txtAdresse.Text = _adresse;
            txtTelPrim.Text = _telPrim;
            txtTelSec.Text = _telSec;
            dateTPEmp.Value = _date;
            richTextBox1.Text = _compParti;
            
            CtrlTypeTest.PopulateLstTypeTest(_emp);
            AfficherLstBox();
            //RemplirListBoxPourModeModif(_emp);
            remplirListBoxUtil(_emp);
            modifier = true;
            employe = CtrlEmploye.emp(_nom + " " + _pren);

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
            //CtrlTypeTest.PopulateLstTypeTest();
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
        private void btnFlecheAjouter_Click(object sender, EventArgs e)
        {
       
            if ((lstBoxTypeTest.Items.Count == 0) || 
                (lstBoxTypeTest.SelectedIndex == -1) || 
                (lstBoxTypeTest.SelectedItems.Count > 1))
            {
                string ad = "Veuillez selectionner un type de test à ajouter.";
                CtrlController.MessageWarnng(ad);             
            }
            else
            {
                CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(lstBoxTypeTest.Text),true);
                AfficherLstBox();
            }
        
        
        }

        private void remplirListBoxUtil(Employe _emp)
        {
            foreach (Utilisateur uti in CtrlUtilisateur.lstUtilisateurAssocEmp(_emp))
            {
                listBox1.Items.Add(uti.nomUtilisateur);
            }
        }
      
        private void bntFlecheRetirer_Click(object sender, EventArgs e)
        {
            if ((lstBoxTypeTestEmp.Items.Count == 0) ||
                (lstBoxTypeTestEmp.SelectedIndex == -1) ||
                (lstBoxTypeTestEmp.SelectedItems.Count > 1))
            {
                string ad = "Veuillez selectionner une type de test à retirer à l'employé.";
                CtrlController.MessageWarnng(ad);
            }
            else
            {
                CtrlTypeTest.ModifierLstBox(CtrlTypeTest.GetTypeTest(lstBoxTypeTestEmp.Text), false);
                AfficherLstBox();
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if ((txtAdresse.Text == "") || (txtNom.Text == "") || (txtPrenom.Text == "") || (txtNom.Text == "") || (txtTelSec.Text == ""))
            {
                MessageBox.Show("Certain champs ne sont pas rempli");
                return;
            }
            if (modifier == false)
            {
                string message;
                message = CtrlEmploye.Ajouter(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtAdresse.Text, txtTelPrim.Text.Trim(), txtTelSec.Text.Trim(), richTextBox1.Text, dateTPEmp.Value);
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
                message = CtrlEmploye.Modifier(txtNom.Text.Trim(), txtPrenom.Text.Trim(), txtAdresse.Text, txtTelPrim.Text.Trim(), txtTelSec.Text.Trim(), richTextBox1.Text, dateTPEmp.Value, employe);
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
            Utilisateur uti = CtrlUtilisateur.utilisateur(listBox1.SelectedItem.ToString());
            frmUtilisateur frmUti = new frmUtilisateur(uti.nomUtilisateur, uti.motPasse, CtrlUtilisateur.lstGrAssUtil(uti), CtrlEmploye.emp(txtNom.Text + " " + txtPrenom.Text));
            frmUti.ShowDialog();
        }

        private void btnCreerUti_Click(object sender, EventArgs e)
        {
            frmUtilisateur frmUti = new frmUtilisateur(CtrlEmploye.emp(txtNom.Text + " " + txtPrenom.Text));
            frmUti.ShowDialog();
        }

        // remplir les infos employé avec les données des R.H.!!
        // À revoir pour l'ordre des items dans les listes (résolu!!!!!)

    }
}
