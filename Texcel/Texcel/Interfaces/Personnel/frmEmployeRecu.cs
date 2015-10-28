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
    public partial class frmEmployeRecu : frmForm
    {
        private List<Employe> employes;
        
        public frmEmployeRecu()
        {
            InitializeComponent();
        }

        private void frmEmployeRecu_Load(object sender, EventArgs e)
        {
            employes = CtrlFileEmployes.GetEmployesFromFile();
            foreach (Employe employe in employes)
            {
                dgvNouveauxEmployes.Rows.Add(employe.nomEmploye, employe.prenomEmploye, employe.adressePostale, employe.numTelPrincipal, employe.numTelSecondaire, employe.dateEmbauche.Date.ToString("yyyy-MM-dd"));
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Une fois le nouvel employé supprimé, il sera impossible de l'ajouter à nouveau sauf si ce dernier est réenvoyé par les R.H.", "Supprimer un nouvel employé", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                CtrlFileEmployes.DeleteEmployeFromFile(employes[dgvNouveauxEmployes.SelectedRows[0].Index], dgvNouveauxEmployes.SelectedRows[0].Index);
                dgvNouveauxEmployes.Rows.RemoveAt(dgvNouveauxEmployes.SelectedRows[0].Index);
            } 
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (dgvNouveauxEmployes.SelectedRows.Count > 0)
            {
                frmAjouterEmploye frmAjouterEmploye = new frmAjouterEmploye(employes[dgvNouveauxEmployes.SelectedRows[0].Index]);
                DialogResult dr = frmAjouterEmploye.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    CtrlFileEmployes.DeleteEmployeFromFile(employes[dgvNouveauxEmployes.SelectedRows[0].Index], dgvNouveauxEmployes.SelectedRows[0].Index);
                    dgvNouveauxEmployes.Rows.RemoveAt(dgvNouveauxEmployes.SelectedRows[0].Index);
                }
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un employé dans la liste.", "Aucun employé selectionné", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }    
    }
}
