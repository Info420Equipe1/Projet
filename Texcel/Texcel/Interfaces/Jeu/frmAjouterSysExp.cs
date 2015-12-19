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
        private bool modif;
        private SysExp modifSysExp;
        private EditionSysExp modifEdition;
        private VersionSysExp modifVersion;

        //Constructeur par défaut
        public frmAjouterSysExp()
        {
            InitializeComponent();
            modif = false;
        }

        //Constructeur avec paramètres
        public frmAjouterSysExp(SysExp _sE, EditionSysExp _eSE, VersionSysExp _vSE)
        {
            InitializeComponent();
            this.Text = "Modifier systeme d'exploitation";
            txtID.Text = _sE.idSysExp.ToString();          
            cmbNom.Text = _sE.nomSysExp;
            cmbEdition.Text = _eSE.nomEdition;
            txtCode.Text = _sE.codeSysExp;
            cmbVersion.Text = _vSE.noVersion;
            rtbCommentaire.Text = _vSE.commSysExp;
            btnEnregistrer.Text = "Modifier";

            txtID.Enabled = false;
            cmbNom.Enabled = true;
            cmbNom.DropDownStyle = ComboBoxStyle.Simple;
            cmbEdition.DropDownStyle = ComboBoxStyle.Simple;
            cmbVersion.DropDownStyle = ComboBoxStyle.Simple;
            modifVersion = _vSE;
            modifEdition = _eSE;
            
            modif = true;
            modifSysExp = _sE;
        }

        //Met l'ID au bon chiffre
        private void frmSysExp_Load(object sender, EventArgs e)
        {
            txtID.Text = (CtrlSysExp.GetCount() + 1).ToString();
        }

        //Ajoute les éléments de la liste de nom
        private void cmbNom_DropDown(object sender, EventArgs e)
        {
            cmbNom.Items.Clear();
            foreach (SysExp sysExp in CtrlSysExp.getListSysExp())
            {
                cmbNom.Items.Add(sysExp.nomSysExp);
            }
        }

        //Sélection d'un système d'exploitation
        private void cmbNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SysExp sysExp = CtrlSysExp.GetSysExp(cmbNom.Text);
            txtCode.Text = sysExp.codeSysExp;
            cmbEdition.Text = "";
            cmbVersion.Text = "";

            //Image du systeme d'exploitation
            try
            {
                picSysExp.Image = Image.FromFile(@"..\..\Images\Jeu\SysExp\" + sysExp.codeSysExp + "logo.png");
            }
            catch (Exception)
            {
                picSysExp.Image = Image.FromFile(@"..\..\Images\Jeu\NoImage.png");
            }
        }

        //Sélection d'une édition
        private void cmbEdition_DropDown(object sender, EventArgs e)
        {
            cmbEdition.Items.Clear();
            if (CtrlSysExp.Verifier(cmbNom.Text))
            {
                SysExp sysExp = CtrlSysExp.GetSysExp(cmbNom.Text);
                foreach (EditionSysExp editionSysExp in sysExp.EditionSysExp)
                {
                    cmbEdition.Items.Add(editionSysExp.nomEdition);
                }
            } 
        }

        //Sélection d'une version
        private void cmbVersion_DropDown(object sender, EventArgs e)
        {
            cmbVersion.Items.Clear();
            if (CtrlSysExp.Verifier(cmbNom.Text))
            {
                foreach (VersionSysExp versionSysExp in CtrlVersionSysExp.Rechercher(CtrlSysExp.GetSysExp(cmbNom.Text), cmbEdition.Text))
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
            bool boolSysExp, boolEdition, boolVersion;
            boolVersion = false;

            //Si le formulaire est en mode "Modification"
            if (modif)
            {
                try
                {
                    CtrlSysExp.modif(cmbNom.Text, txtCode.Text, rtbCommentaire.Text, modifSysExp, cmbEdition.Text, modifEdition, cmbVersion.Text, modifVersion);
                    MessageBox.Show("Modification reussie", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Une erreur est survenue", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            //Si le formulaire est en mode "Ajout"
            else
            {
                if (cmbNom.Text == "")
                {
                    MessageBox.Show("Veuillez entrer un nom.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                //Vérifie si les champs sont remplis ou si l'entrée existe dans la BD.
                DialogResult rep = MessageBox.Show("Voulez-vous ajouter ce système d'exploitation ?", "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep == DialogResult.Yes)
                {
                    boolSysExp = CtrlSysExp.Ajouter(cmbNom.Text.Trim(), txtCode.Text.Trim(), rtbCommentaire.Text.Trim());
                    SysExp sysExp = CtrlSysExp.GetSysExp(cmbNom.Text);
                    boolEdition = CtrlEditionSysExp.Ajouter(sysExp, cmbEdition.Text.Trim());

                    if (cmbEdition.Text != "")
                    {
                        EditionSysExp editionSysExp = CtrlEditionSysExp.Rechercher(CtrlSysExp.GetSysExp(cmbNom.Text), cmbEdition.Text).First();
                        boolVersion = CtrlVersionSysExp.Ajouter(sysExp, editionSysExp, cmbVersion.Text.Trim(), rtbCommentaire.Text.Trim());
                    }

                    if (boolSysExp || boolEdition || boolVersion)
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
}
