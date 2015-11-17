using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;
using TexcelWeb.Classes;


namespace TexcelWeb
{
    public partial class CreerCasTest : System.Web.UI.Page
    {
        bool modif;
        CasTest casTest;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Mode ajouter 
            modif = false;
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
            ChargerDropDownList();
            txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));
            //Mode modifier
            if (Session["casTest"] != null)
            {
                modif = true;
                casTest = (CasTest)Session["casTest"];
                Session["casTest"] = null;
                txtNomCasTest.Text = casTest.nomCasTest;
                txtCodeCasTest.Text = casTest.codeCasTest;
                dropDownProjet.Text = casTest.cProjet.nomProjet;
                try
                {
                    dropDownDifficulteCasTest.Text = casTest.Difficulte.nomDiff;
                    dropDownPrioritéCasTest.Text = casTest.NiveauPriorite.nomNivPri;
                    dropDownTypeTestCasTest.Text = casTest.TypeTest.nomTest;
                }
                catch(Exception)
                { }
                //affiche pas La date pour l'instant
                txtDateCreationCasTest.Text = ((DateTime)(casTest.dateCreation)).ToShortDateString();
                txtDateLivraisonCasTest.Text = ((DateTime)(casTest.dateLivraison)).ToShortDateString();
                rtxtDescriptionCasTest.Text = casTest.descCasTest;
            }
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!modif)
            {
                if (CtrlCasTest.Ajouter(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(String.Format("{0}", Request.Form["DropDownProjet"])), CtrlDifficulte.GetDiff(String.Format("{0}", Request.Form["dropDownDifficulteCasTest"])), CtrlNivPriorite.GetNivPrio(String.Format("{0}", Request.Form["dropDownPrioritéCasTest"])), Convert.ToDateTime(txtDateCreationCasTest.Text), Convert.ToDateTime(txtDateLivraisonCasTest.Text), CtrlTypeTest.GetTypeTest(String.Format("{0}", Request.Form["dropDownTypeTestCasTest"])), rtxtDescriptionCasTest.Text))
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
                if (CtrlCasTest.Modifier(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(String.Format("{0}", Request.Form["DropDownProjet"])), CtrlDifficulte.GetDiff(String.Format("{0}", Request.Form["dropDownDifficulteCasTest"])), CtrlNivPriorite.GetNivPrio(String.Format("{0}", Request.Form["dropDownPrioritéCasTest"])), Convert.ToDateTime(txtDateCreationCasTest.Text), Convert.ToDateTime(txtDateLivraisonCasTest.Text), CtrlTypeTest.GetTypeTest(String.Format("{0}", Request.Form["dropDownTypeTestCasTest"])), rtxtDescriptionCasTest.Text, casTest))
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
            dropDownDifficulteCasTest.Items.Clear();
            dropDownPrioritéCasTest.Items.Clear();

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
                dropDownDifficulteCasTest.Items.Add(diff.nomDiff);
            }
            foreach (NiveauPriorite nivPrio in CtrlNivPriorite.GetLstNivPrio())
            {
                dropDownPrioritéCasTest.Items.Add(nivPrio.nomNivPri);
            }
        }

        protected void btnCopier_Click(object sender, EventArgs e)
        {
           
        }
    }
}