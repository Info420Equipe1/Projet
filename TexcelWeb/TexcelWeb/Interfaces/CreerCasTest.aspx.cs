using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;


namespace TexcelWeb
{
    public partial class CreerCasTest : System.Web.UI.Page
    {
        bool modif;
        CasTest casTest;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargerDropDownList();
            txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));
            //Pour l'instant
            modif = false;
            //string modife = Application[0].ToString();
            //if (modife == "modif")
            //{
            //    modif = true;
            //    Remplir les champs pour modif
            //}
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!modif)
            {
                if (CtrlCasTest.Ajouter(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(dropDownProjet.Text), CtrlDifficulte.GetDiff(txtDifficulteCasTest.Text), CtrlNivPriorite.GetNivPrio(txtPrioritéCasTest.Text), Convert.ToDateTime(txtDateCreationCasTest.Text), Convert.ToDateTime(txtDateLivraisonCasTest.Text), CtrlTypeTest.GetTypeTest(dropDownTypeTestCasTest.Text), rtxtDescriptionCasTest.Text))
                {
                    Response.Write("<script type=\"text/javascript\">alert('Cas de test créé');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
                }
            }
            else
            {
                if (CtrlCasTest.Modifier(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(dropDownProjet.Text), CtrlDifficulte.GetDiff(txtDifficulteCasTest.Text), CtrlNivPriorite.GetNivPrio(txtPrioritéCasTest.Text), Convert.ToDateTime(txtDateCreationCasTest.Text), Convert.ToDateTime(txtDateLivraisonCasTest.Text), CtrlTypeTest.GetTypeTest(dropDownTypeTestCasTest.Text), rtxtDescriptionCasTest.Text, CtrlCasTest.GetCasTestByNom(casTest.nomCasTest)))
                {
                    Response.Write("<script type=\"text/javascript\">alert('Cas de test modifié');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
                }
            }
           
        }
        protected void ChargerDropDownList()
        {
            dropDownProjet.Items.Clear();
            dropDownTypeTestCasTest.Items.Clear();
            txtDifficulteCasTest.Items.Clear();
            txtPrioritéCasTest.Items.Clear();

            foreach (cProjet proj in CtrlProjet.GetListProjet())
            {
                dropDownProjet.Items.Add(proj.nomProjet);
            }
            foreach (TypeTest tT in CtrlTypeTest.GetLstTypeTest())
            {
                dropDownTypeTestCasTest.Items.Add(tT.nomTest);
            }
            foreach (Difficulte diff in CtrlDifficulte.GetLstDiff())
            {
                txtDifficulteCasTest.Items.Add(diff.nomDiff);
            }
            foreach (NiveauPriorite nivPrio in CtrlNivPriorite.GetLstNivPrio())
            {
                txtPrioritéCasTest.Items.Add(nivPrio.nomNivPri);
            }
        }

        protected void btnCopier_Click(object sender, EventArgs e)
        {
           
        }
    }
}