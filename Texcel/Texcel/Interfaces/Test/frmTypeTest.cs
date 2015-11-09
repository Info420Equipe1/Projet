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

namespace Texcel.Interfaces.Test
{
    public partial class frmTypeTest : Form
    {
        public frmTypeTest()
        {
            InitializeComponent();
        }

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();

            foreach (TypeTest tT in CtrlTypeTest.lstTypeTest())
            {
                cmbNom.Items.Add(tT.nomTypeTest);
            }
        }

        private void frmTypeTest_Load(object sender, EventArgs e)
        {
            txtID.Text = (CtrlTypeTest.lstTypeTest().Count + 1).ToString();
        }

        private void cmbNom_TextUpdate(object sender, EventArgs e)
        {
            foreach (TypeTest tT in CtrlTypeTest.lstTypeTest())
            {
                if (cmbNom.Text == tT.nomTypeTest)
                {
                    btnEnregistrer.Text = "Modifier";
                    txtID.Text = tT.idTypeTest.ToString();
                    rtbCommentaire.Text = tT.descTypeTest;
                    break;
                }
                else
                {
                    btnEnregistrer.Text = "Enregistrer";
                    txtID.Text = (CtrlTypeTest.lstTypeTest().Count + 1).ToString();
                    rtbCommentaire.Text = "";
                }
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez ajouter un nom!", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult DR;
            string message;

            if (CtrlTypeTest.Verifier(cmbNom.Text.Trim()))
            {
                message = "Vous êtes en train de modifier un type de plateforme, voulez-vous continuer?";
                DR = MessageBox.Show(message, "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                {
                    message = CtrlTypeTest.Modifier(cmbNom.Text, rtbCommentaire.Text);
                    if (message.Contains("erreur"))
                    {
                        MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            else
            {
                message = CtrlTypeTest.Ajouter(cmbNom.Text.Trim(), rtbCommentaire.Text.Trim());
                if (message.Contains("erreur"))
                {
                    MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmbNom.Text = "";
                    rtbCommentaire.Text = "";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
