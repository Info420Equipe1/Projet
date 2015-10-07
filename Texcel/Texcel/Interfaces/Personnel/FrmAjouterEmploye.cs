﻿using System;
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
        public frmAjouterEmploye()
        {
            InitializeComponent();
        }

        private void frmAjouterEmploye_Load(object sender, EventArgs e)
        {
            CtrlTypeTest.PopulateLstTypeTest();
            AfficherLstBox();
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
            if ((txtAdresse.Text == "") || (txtNom.Text == "") || (txtPrenom.Text == "") || (txtNom.Text == "") || (txtTelSec.Text == "") || (richTextBox1.Text == ""))
            {
                MessageBox.Show("Certain champs ne sont pas rempli");
                return;
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // remplir les infos employé avec les données des R.H.!!
        // À revoir pour l'ordre des items dans les listes (résolu!!!!!)

    }
}
