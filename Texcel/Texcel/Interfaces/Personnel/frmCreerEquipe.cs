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
    public partial class frmCreerEquipe : frmForm
    {
        bool Modification = false;
        public frmCreerEquipe()
        {
            InitializeComponent();
        }

        //Lorsque la fenetre est ouverte via recherche d'une équipe
        public frmCreerEquipe(Equipe _equ)
        {
            txtNom.Text = _equ.nomEquipe;
            //cmbNom.Text = chef dequipe
            //rtbCommentaire.Text = commentaire
            Modification = true;
        }

        private void frmCreerEquipe_Load(object sender, EventArgs e)
        {
            ChargerPage();
        }

        public void ChargerPage()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            //Load list box 1
            foreach (Employe emp in CtrlEmploye.listEmploye())
            {
                listBox1.Items.Add(emp.nomEmploye + " " + emp.prenomEmploye);
            }
            txtNom.Text = "";
            rtbCommentaire.Text = "";
            cmbNom.Text = "";
        }

        //Ajouter un employé dans list box 2
        private void button3_Click(object sender, EventArgs e)
        {
            if ((listBox1.Items.Count == 0) || (listBox1.SelectedIndex == -1) || (listBox1.SelectedItems.Count > 1))
            {
                MessageBox.Show("Veuillez selectionner un employé à ajouter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomEmploye = (string)listBox1.SelectedItem;
            listBox2.Items.Add(nomEmploye);
            listBox1.Items.Remove(nomEmploye);
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

            foreach (string nom in listBox2.Items)
            {
                listEmp.Add(CtrlEmploye.emp(nom));
            }
            if (Modification == false)
            {
                message = CtrlEquipe.Ajouter(txtNom.Text, Convert.ToInt16(listBox2.Items.Count), rtbCommentaire.Text, CtrlEmploye.emp(cmbNom.Text), listEmp);
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
                //Modification de l'équipe
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
            if ((listBox1.Items.Count == 0) || (listBox1.SelectedIndex == -1) || (listBox1.SelectedItems.Count < 2))
            {
                MessageBox.Show("Veuillez selectionner plusieurs employées à ajouter.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListBox.SelectedObjectCollection lstBox= listBox1.SelectedItems;
            string emp;
            int num = lstBox.Count;
            for (int i = 0; i < num; i++)
            {
                emp = lstBox[0].ToString();
                listBox1.Items.Remove(emp);
                listBox2.Items.Add(emp);
            }
        }

        //Enleve des employés dans list box 2
        private void button2_Click(object sender, EventArgs e)
        {
            if ((listBox2.Items.Count == 0) || (listBox2.SelectedIndex == -1) || (listBox2.SelectedItems.Count < 2))
            {
                MessageBox.Show("Veuillez selectionner plusieurs employées à enlever.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListBox.SelectedObjectCollection lstBox = listBox2.SelectedItems;
            string emp;
            int num = lstBox.Count;
            for (int i = 0; i < num; i++)
            {
                emp = lstBox[0].ToString();
                listBox2.Items.Remove(emp);
                listBox1.Items.Add(emp);
            }
        }

        //Enleve un employé de la list box 2
        private void button4_Click(object sender, EventArgs e)
        {
            if ((listBox2.Items.Count == 0) || (listBox2.SelectedIndex == -1) || (listBox2.SelectedItems.Count > 1))
            {
                MessageBox.Show("Veuillez selectionner un employé à enlever.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomEmploye = (string)listBox2.SelectedItem;
            listBox1.Items.Add(nomEmploye);
            listBox2.Items.Remove(nomEmploye);
        }
    }
}
