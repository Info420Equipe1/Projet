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
            Utilisateur currentUser = CtrlController.GetCurrentUser();
            foreach (Groupe groupe in currentUser.Groupe)
            {
                List<int> lstDroits = CtrlController.GetDroits(groupe);
                if (!lstDroits.Contains(19) && !lstDroits.Contains(20))
                {
                    boxProjet.Visible = false;
                    menuProjet.Visible = false;
                    lienAjouterProjet.Visible = false;
                    lienProjetEquipe.Visible = false;
                    ddlFiltre.Items.Remove("Projet");
                    ddlFiltre.Items.Remove("JeuProjet");
                    ddlFiltre.Items.Remove("ProjetGenre");
                    ddlFiltre.Items.Remove("ProjeTheme");
                    ddlFiltre.Items.Remove("ProjetClassification");
                    ddlFiltre.Items.Remove("ProjetEquipe");
                    ddlFiltre.Items.Remove("ProjetCasTest");
                }
                else if (groupe.idGroupe == 1)
                {
                    lienProjetEquipe.Visible = false;
                }
                if (!lstDroits.Contains(21) && !lstDroits.Contains(22))
                {
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                    ddlFiltre.Items.Remove("CasTest");
                    ddlFiltre.Items.Remove("ProjetCasTest");
                    ddlFiltre.Items.Remove("CasTestBilletTravail");
                }
                else if (groupe.idGroupe == 2)
                {
                    lienAjouterProjet.Visible = false;
                }
                if (!lstDroits.Contains(24))
                {
                    boxBilletTravail.Visible = false;
                    menuBilletTravail.Visible = false;
                    lienBilletChefEquipe.Visible = false;
                    lienGestionBillets.Visible = false;
                    ddlFiltre.Items.Remove("BilletTravail");
                    ddlFiltre.Items.Remove("EmployeBilletTravail");
                    ddlFiltre.Items.Remove("BilletTravailPriorite");
                    ddlFiltre.Items.Remove("BilletTravailStatut");
                    ddlFiltre.Items.Remove("CasTestBilletTravail");
                }
                else if (groupe.idGroupe == 3)
                {
                    boxProjet.Visible = false;
                    menuProjet.Visible = false;
                    lienAjouterProjet.Visible = false;
                    lienProjetEquipe.Visible = false;
                    boxCasTest.Visible = false;
                    menuCasTest.Visible = false;
                    lienCasTest.Visible = false;
                }
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

        protected void btnCocher_Click(object sender, EventArgs e)
        {
            CtrlCopier.Coche_Dechoche(true, gvCopierCasTest);
        }

        protected void btnDechocher_Click(object sender, EventArgs e)
        {
            CtrlCopier.Coche_Dechoche(false, gvCopierCasTest);
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