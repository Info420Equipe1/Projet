﻿using System;
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

namespace Texcel.Interfaces.Test
{
    public partial class frmTypeTest : Form
    {
        public frmTypeTest()
        {
            InitializeComponent();
        }
        //Fill dropdown nom
        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();

            foreach (TypeTest tT in CtrlTypeTest.lstTypeTest())
            {
                cmbNom.Items.Add(tT.nomTest);
            }
        }

        private void frmTypeTest_Load(object sender, EventArgs e)
        {
            txtID.Text = (CtrlTypeTest.lstTypeTest().Count + 1).ToString();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cmbNom.Text == "")
            {
                CtrlController.MessageErreur("Veuillez ajouter un nom.");
                return;
            }
            DialogResult DR;
            string message;

            if (CtrlTypeTest.Verifier(cmbNom.Text.Trim()))
            {
                message = "Vous êtes en train de modifier un type de plateforme, voulez-vous continuer?";
                DR = CtrlController.getDR(message);

                if (DR == DialogResult.Yes)
                {
                    message = CtrlTypeTest.Modifier(cmbNom.Text, rtbCommentaire.Text);
                    if (message.Contains("erreur"))
                    {
                        CtrlController.MessageErreur(message);
                        return;
                    }
                    else
                    {
                        CtrlController.MessageSucces(message);
                        Reaffichage();
                    }
                }
            }
            else
            {
                message = CtrlTypeTest.Ajouter(cmbNom.Text.Trim(), rtbCommentaire.Text.Trim());
                if (message.Contains("erreur"))
                {
                    CtrlController.MessageErreur(message);
                    return;
                }
                else
                {
                    CtrlController.MessageSucces(message);
                    cmbNom.Text = "";
                    rtbCommentaire.Text = "";
                    Reaffichage();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeTest tT = CtrlTypeTest.GetTypeTest(cmbNom.Text);
            txtID.Text = tT.idTest.ToString();
            rtbCommentaire.Text = tT.descTest;
        }

        private void Reaffichage()
        {
            txtID.Text = (CtrlTypeTest.lstTypeTest().Count + 1).ToString();
            cmbNom.Items.Clear();

            foreach (TypeTest tT in CtrlTypeTest.lstTypeTest())
            {
                cmbNom.Items.Add(tT.nomTest);
            }
        }
    }
}
