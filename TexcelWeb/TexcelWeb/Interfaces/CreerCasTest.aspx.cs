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
        protected void Page_Load(object sender, EventArgs e)
        {
            ChargerDropDownList();
            txtDateCreationCasTest.Text = Convert.ToString(DateTime.Today.ToString("d"));
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (CtrlCasTest.Ajouter(txtCodeCasTest.Text, txtNomCasTest.Text, CtrlProjet.GetProjet(dropDownProjet.Text), CtrlTypeTest.GetTypeTest(dropDownTypeTestCasTest.Text)))
            {
                Response.Write("<script type=\"text/javascript\">alert('Cas de test créé');</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Une erreur est survenue');</script>");
            }
           
        }
        protected void ChargerDropDownList()
        {
            dropDownProjet.Items.Clear();
            dropDownTypeTestCasTest.Items.Clear();

            foreach (cProjet proj in CtrlProjet.GetListProjet())
            {
                dropDownProjet.Items.Add(proj.nomProjet);
            }
            foreach (TypeTest tT in CtrlTypeTest.GetLstTypeTest())
            {
                dropDownTypeTestCasTest.Items.Add(tT.nomTypeTest);
            }
        }

        protected void btnCopier_Click(object sender, EventArgs e)
        {
            DirectoryInfo monrepertoire = new DirectoryInfo("Chemin de ton repertoire"); 
              //liste tous les fichier ".txt" du repertoir 
            FileInfo[] mesfichiers = monrepertoire.GetFiles("*.*"); 
              //boucle sur les fichiers pour les traiter 

            foreach (FileInfo files in mesfichiers) 
            { 
              
            } 
        }
    }
}