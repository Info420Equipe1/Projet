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
using Texcel.Classes.Projet;
using Texcel.Classes;

namespace Texcel.Interfaces.Personnel
{
    public partial class frmCreerEquipe : frmForm
    {
        bool Modification = false;
        int id;
        public frmCreerEquipe()
        {
            InitializeComponent();
            ChargerPage();
        }

        //Lorsque la fenetre est ouverte via recherche d'une équipe
        public frmCreerEquipe(Equipe _equ)
        {
            
            InitializeComponent();
            id = _equ.idEquipe;
            txtNom.Text = _equ.nomEquipe;
            cmbNom.Text = _equ.Employe.nomEmploye+" "+_equ.Employe.prenomEmploye;
            cmbProjet.Text = CtrlProjet.getNomProjet(_equ.codeProjet);
            rtbCommentaire.Text = _equ.descEquipe;
            foreach (Employe employe in _equ.Employe1)
            {
                lstTesteurEquipe.Items.Add(employe.nomEmploye+" " + employe.prenomEmploye);
            }
            foreach (AllTesteurs testeur in CtrlAdmin.GetAllTesteursView())
            {
                lstTesteurGlobal.Items.Add(testeur.nomEmploye + " " + testeur.prenomEmploye);
            }
            Modification = true;
            btnEnregistrer.Text = "Modifier";
            this.Text = "Modifier équipe";
        }

        private void frmCreerEquipe_Load(object sender, EventArgs e)
        {
            
        }

        public void ChargerPage()
        {
            lstTesteurGlobal.Items.Clear();
            lstTesteurEquipe.Items.Clear();
            //Load list box 1
            foreach (AllTesteurs testeur in CtrlAdmin.GetAllTesteursView())
            {
                lstTesteurGlobal.Items.Add(testeur.nomEmploye + " " + testeur.prenomEmploye);
            }
            txtNom.Text = "";
            rtbCommentaire.Text = "";
            cmbNom.Text = "";
        }

        //Ajouter un employé dans list box 2
        private void button3_Click(object sender, EventArgs e)
        {
            if ((lstTesteurGlobal.Items.Count == 0) || (lstTesteurGlobal.SelectedIndex == -1) || (lstTesteurGlobal.SelectedItems.Count > 1))
            {
                MessageBox.Show("Veuillez selectionner un employé à ajouter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomEmploye = (string)lstTesteurGlobal.SelectedItem;
            lstTesteurEquipe.Items.Add(nomEmploye);
            lstTesteurGlobal.Items.Remove(nomEmploye);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            List<Employe> listEmp = new List<Employe>();
            string message;

            if (txtNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un `chef d'équipe!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string nom in lstTesteurEquipe.Items)
            {
                listEmp.Add(CtrlEmploye.emp(nom));
            }
            if (Modification == false)
            {
                cProjet projet = CtrlProjet.getProjet(cmbProjet.Text);
                message = CtrlEquipe.Ajouter(txtNom.Text, projet.codeProjet, Convert.ToInt16(lstTesteurEquipe.Items.Count), rtbCommentaire.Text, CtrlEmploye.emp(cmbNom.Text), listEmp, CtrlProjet.getProjet(cmbProjet.Text));
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerPage();
                }
            }
            else
            {
                cProjet projet = CtrlProjet.getProjet(cmbProjet.Text);
                message = CtrlEquipe.Modifier(id, txtNom.Text, projet.codeProjet, Convert.ToInt16(lstTesteurEquipe.Items.Count), rtbCommentaire.Text, CtrlEmploye.emp(cmbNom.Text), listEmp);
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

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (Employe emp in CtrlEmploye.listEmployeChefEquipe())
            {
                cmbNom.Items.Add(emp.nomEmploye + " " + emp.prenomEmploye);
            }
        }

        //Ajoutes des employés dans list box 2
        private void button1_Click(object sender, EventArgs e)
        {
            if ((lstTesteurGlobal.Items.Count == 0) || (lstTesteurGlobal.SelectedIndex == -1) || (lstTesteurGlobal.SelectedItems.Count < 2))
            {
                MessageBox.Show("Veuillez selectionner plusieurs employées à ajouter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListBox.SelectedObjectCollection lstBox= lstTesteurGlobal.SelectedItems;
            string emp;
            int num = lstBox.Count;
            for (int i = 0; i < num; i++)
            {
                emp = lstBox[0].ToString();
                lstTesteurGlobal.Items.Remove(emp);
                lstTesteurEquipe.Items.Add(emp);
            }
        }

        //Enleve des employés dans list box 2
        private void button2_Click(object sender, EventArgs e)
        {
            if ((lstTesteurEquipe.Items.Count == 0) || (lstTesteurEquipe.SelectedIndex == -1) || (lstTesteurEquipe.SelectedItems.Count < 2))
            {
                MessageBox.Show("Veuillez selectionner plusieurs employées à enlever.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListBox.SelectedObjectCollection lstBox = lstTesteurEquipe.SelectedItems;
            string emp;
            int num = lstBox.Count;
            for (int i = 0; i < num; i++)
            {
                emp = lstBox[0].ToString();
                lstTesteurEquipe.Items.Remove(emp);
                lstTesteurGlobal.Items.Add(emp);
            }
        }

        //Enleve un employé de la list box 2
        private void button4_Click(object sender, EventArgs e)
        {
            if ((lstTesteurEquipe.Items.Count == 0) || (lstTesteurEquipe.SelectedIndex == -1) || (lstTesteurEquipe.SelectedItems.Count > 1))
            {
                MessageBox.Show("Veuillez selectionner un employé à enlever.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomEmploye = (string)lstTesteurEquipe.SelectedItem;
            lstTesteurGlobal.Items.Add(nomEmploye);
            lstTesteurEquipe.Items.Remove(nomEmploye);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     

        private void cmbProjet_DropDown(object sender, EventArgs e)
        {
            cmbProjet.Items.Clear();

            foreach (cProjet proj in CtrlProjet.listDeProjet())
            {
                cmbProjet.Items.Add(proj.nomProjet);
            }
        }
    }
}
