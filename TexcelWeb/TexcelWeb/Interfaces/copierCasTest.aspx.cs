using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//ceux ajoutés
using System.Data;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes;
using System.IO;


namespace TexcelWeb.Interfaces
{
	public partial class copierCasTest : System.Web.UI.Page
    {

        Utilisateur currentUser;
        public copierCasTest()
        {
            
        }

		protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                //Premier loading de la page
                if (CtrlController.GetCurrentUser() == null)
                {
                    //Not logged in
                    Response.Redirect("login.aspx");
                }
                else
                {
                    //Formatage Bienvenue, [NomUtilisateur] et la Date
                    currentUser = CtrlController.GetCurrentUser();
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;    
                }
                ChargerPage();
            }
		}
        private void ChargerPage()
        {            
            Session["TypeCopie"] = Request.QueryString["Param"];

            //Copier des fichiers dans un casTest
            if (Session["TypeCopie"] != null && Session["TypeCopie"].ToString() == "CasTest")
            {
                AfficherGV(Session["TypeCopie"].ToString());
                ddlFiltre.Enabled = false;
            }
            else
            {
                // on veut copier des casTest pour un projet donc on affiche tous les cas de test 
                //,mais le filtre n'est pas disabled
                AfficherGV(ddlFiltre.Text);
                ddlFiltre.Enabled = true;
            }
            
            
        
        }

        private void AfficherGV(string _filtre)
        {           

            switch (_filtre)
            {
                case "Projet":
                    gvCopierCasTest.DataSourceID = "edsCasTest";
                    if (txtChampRecherche.Text =="")
                    {
                         edsCasTest.Where = "it.[codeProjet] like '%" + txtChampRecherche.Text.Trim() + "%'";
                    }
                    else
                    {
                        edsCasTest.Where = "it.[codeProjet] like '" + txtChampRecherche.Text.Trim() + "'";
                    }                   
                    gvCopierCasTest.DataBind();
                    break;

                case "CasTest":
                    gvCopierCasTest.DataSourceID = "edsCasTest";
                    edsCasTest.Where = "it.[tagCasTest] like '%" + txtChampRecherche.Text + "%'";
                    gvCopierCasTest.DataBind();
                    break;
                default:
                    break;
            }
            try
            {
                gvCopierCasTest.HeaderRow.Cells[1].Text = "Code du CasTest";
                gvCopierCasTest.HeaderRow.Cells[2].Text = "Nom du CasTest";
                gvCopierCasTest.HeaderRow.Cells[3].Text = "Code du Projet";
                gvCopierCasTest.HeaderRow.Cells[4].Text = "Date de Creation";
                gvCopierCasTest.HeaderRow.Cells[5].Text = "Date de Livraison";
            }
            catch (Exception)
            {                
               
            }
            
            CtrlCopier.SauvegarderDonnees(gvCopierCasTest);
        }

        protected void btnRechercher_Click(object sender, EventArgs e)
        {
            ChargerPage();          
        }
       
        protected void btnCopierMesSelections_Click(object sender, EventArgs e)
        {
            CtrlCopier.SauvegarderDonnees(gvCopierCasTest);
            List<CasTest> lstCTCopier = CtrlCopier.getLstCasTestCoche();
            List<FileInfo> lstFile = CtrlCasTest.PopulateLstPathsFile(lstCTCopier);

            if (Session["TypeCopie"].ToString() == "CasTest")
            {

                CasTest casTest = (CasTest)Session["casTest"];                              
                foreach (FileInfo file in lstFile)
                {
                    CtrlCopier.SaveFileToFolder(casTest, file);
                }
                this.Form.Dispose();
                Response.Redirect("CreerCasTest.aspx");

            }
            else
            {
                //On copie des casTests dans un projet 
                cProjet proj = (cProjet)Session["monProjet"];
                Dictionary<CasTest, List<FileInfo>> dictCtClone = CtrlProjet.ClonerLstCt(lstCTCopier, proj);

                foreach (KeyValuePair<CasTest, List<FileInfo>> maPair in dictCtClone)
                {
                    CtrlCopier.CreationDossier(proj, maPair.Key);
                    foreach (FileInfo fi in maPair.Value)
                    {
                        CtrlCopier.SaveFileToFolder(maPair.Key, fi);
                    }
                    CtrlCasTest.Ajouter(maPair.Key);
                }



                this.Form.Dispose();
                Response.Redirect("creerProjet.aspx");

            }
            
        }



        
	}
}