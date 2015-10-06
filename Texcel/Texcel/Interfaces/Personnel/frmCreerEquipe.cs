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
        }

        private void frmCreerEquipe_Load(object sender, EventArgs e)
        {
            //Load list box 1
            foreach (Employe emp in CtrlEmploye.listEmploye())
            {
                listBox1.Items.Add(emp.nomEmploye + " " + emp.prenomEmploye);
            }
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

            foreach (string nom in listBox2.Items)
            {
                listEmp.Add(CtrlEmploye.emp(nom));
            }

            CtrlEquipe.Ajouter(txtNom.Text, Convert.ToInt16(listBox2.Items.Count), rtbCommentaire.Text, listEmp);
        }
    }
}
