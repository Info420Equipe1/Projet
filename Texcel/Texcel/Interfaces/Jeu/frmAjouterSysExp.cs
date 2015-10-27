using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Texcel.Classes.Jeu;

namespace Texcel.Interfaces.Jeu
{
    public partial class frmAjouterSysExp : frmForm
    {
        public frmAjouterSysExp()
        {
            InitializeComponent();
        }
        public frmAjouterSysExp(SysExp _sE, EditionSysExp _eSE, VersionSysExp _vSE)
        {
            InitializeComponent();
           
            txtID.Text = _sE.idSysExp.ToString();          
            cmbNom.Text = _sE.nomSysExp;
            cmbEdition.Text = _eSE.nomEdition;
            txtCode.Text = _sE.codeSysExp;
            cmbVersion.Text = _vSE.noVersion;
            rtbCommentaire.Text = _vSE.commSysExp;
            btnEnregistrer.Text = "Modifier";

            txtID.Enabled = false;
            cmbNom.Enabled = false;
            cmbEdition.Enabled = false;
            txtCode.Enabled = false;
            cmbVersion.Enabled = false;           
        }

        private void frmSysExp_Load(object sender, EventArgs e)
        {
            txtID.Text = (CtrlSysExp.GetCount() + 1).ToString();
        }

        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (SysExp sysExp in CtrlSysExp.Rechercher())
            {
                cmbNom.Items.Add(sysExp.nomSysExp);
            }
        }

        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SysExp sysExp = CtrlSysExp.Rechercher(cmbNom.Text).First();
            // txtID.Text = sysExp.idSysExp.ToString();
            txtCode.Text = sysExp.codeSysExp;
            //rtbCommentaire.Text = sysExp.descSysExp;
            cmbEdition.Text = "";
            cmbVersion.Text = "";
        }

        private void cmbEdition_DropDown(object sender, EventArgs e)
        {
            cmbEdition.Items.Clear();
            if (CtrlSysExp.Verifier(cmbNom.Text))
            {
                SysExp sysExp = CtrlSysExp.Rechercher(cmbNom.Text).First();
                foreach (EditionSysExp editionSysExp in sysExp.EditionSysExp)
                {
                    cmbEdition.Items.Add(editionSysExp.nomEdition);
                }
            } 
        }

        private void cmbVersion_DropDown(object sender, EventArgs e)
        {
            cmbVersion.Items.Clear();
            if (CtrlSysExp.Verifier(cmbNom.Text))
            {
                foreach (VersionSysExp versionSysExp in CtrlVersionSysExp.Rechercher(CtrlSysExp.Rechercher(cmbNom.Text).First(), cmbEdition.Text))
                {
                    cmbVersion.Items.Add(versionSysExp.noVersion);
                } 
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cmbNom.Text = "";
            cmbEdition.Text = "";
            txtCode.Text = "";
            cmbVersion.Text = "";
            rtbCommentaire.Text = "";
            this.Close();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            bool boolS, boolE, boolV;
            boolV = false;



            if(cmbNom.Text == "")
            {
                MessageBox.Show("Veuillez entrer un nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DialogResult rep = MessageBox.Show("Voulez-vous ajouter ce système d'exploitation ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rep == DialogResult.Yes)
            {
                boolS = CtrlSysExp.Ajouter(cmbNom.Text.Trim(), txtCode.Text.Trim(), rtbCommentaire.Text.Trim());
                SysExp sysExp = CtrlSysExp.Rechercher(cmbNom.Text).First();
                boolE = CtrlEditionSysExp.Ajouter(sysExp, cmbEdition.Text.Trim());

                if (cmbEdition.Text != "")
                {
                    EditionSysExp editionSysExp = CtrlEditionSysExp.Rechercher(CtrlSysExp.Rechercher(cmbNom.Text).First(), cmbEdition.Text).First();
                    boolV = CtrlVersionSysExp.Ajouter(sysExp, editionSysExp, cmbVersion.Text.Trim(), rtbCommentaire.Text.Trim());
                }

                if (boolS || boolE || boolV)
                {
                    MessageBox.Show("Le système d'exploitation a été ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbNom.Text = "";
                    cmbEdition.Text = "";
                    txtCode.Text = "";
                    cmbVersion.Text = "";
                    rtbCommentaire.Text = "";
                }
                else
                {
                    MessageBox.Show("Le système d'exploitation n'a pas été ajouté. Vérifiez si les champs sont biens remplis ou si l'entrée existe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
