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
using System.IO;


namespace TexcelWeb.Interfaces
{
	public partial class copierCasTest : System.Web.UI.Page
    {

        string TypeCopie;
        public copierCasTest()
        {
            
        }

		protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                TypeCopie = Request.QueryString["Param"];
                ChargerPage();
            }
		}
        private void ChargerPage()
        {
            if (TypeCopie != null)
            {
                AfficherGV(TypeCopie);
             
            }
            else
            {
                AfficherGV(ddlFiltre.Text);
            }

            ddlFiltre.Enabled = false;
        
        }

        private void AfficherGV(string _filtre)
        {
            
            switch (_filtre)
            {
                case "Projet":
                    ddlFiltre.SelectedValue = "Projet";
                    gvCopierCasTest.DataSourceID = "edsProjet";
                    edsProjet.Where = "it.[tagProjet] like '%" + txtChampRecherche.Text + "%'";
                    gvCopierCasTest.DataBind();
                    gvCopierCasTest.HeaderRow.Cells[1].Text = "Code du Projet";
                    gvCopierCasTest.HeaderRow.Cells[2].Text = "Nom du Projet";
                    gvCopierCasTest.HeaderRow.Cells[3].Text = "Chef de Projet";
                    gvCopierCasTest.HeaderRow.Cells[4].Text = "Date de Creation";
                    gvCopierCasTest.HeaderRow.Cells[5].Text = "Date de Livraison";
                    break;

                case "CasTest":
                    ddlFiltre.SelectedIndex = 1;
                    gvCopierCasTest.DataSourceID = "edsCasTest";
                    edsProjet.Where = "it.[tagCasTest] like '%" + txtChampRecherche.Text + "%'";
                    gvCopierCasTest.DataBind();
                    gvCopierCasTest.HeaderRow.Cells[1].Text = "Code du CasTest";
                    gvCopierCasTest.HeaderRow.Cells[2].Text = "Nom du CasTest";
                    gvCopierCasTest.HeaderRow.Cells[3].Text = "Code du Projet";
                    gvCopierCasTest.HeaderRow.Cells[4].Text = "Date de Creation";
                    gvCopierCasTest.HeaderRow.Cells[5].Text = "Date de Livraison";
                  
                    break;

                default:
                    break;
            }
            CtrlCopier.SauvegarderDonnees(gvCopierCasTest);
        }

        protected void btnRechercher_Click(object sender, EventArgs e)
        {
            TypeCopie = Request.QueryString["Param"];           
            AfficherGV(TypeCopie);            
        }
       
        protected void btnCopierMesSelections_Click(object sender, EventArgs e)
        {
            CtrlCopier.SauvegarderDonnees(gvCopierCasTest);
            CtrlCopier.CopierElement();

            if (TypeCopie =="CasTest")
            {
                CasTest casTest = (CasTest)Session["casTest"];                               
                foreach (FileInfo file in CtrlCasTest.PopulateLstPathsFile(CtrlCasTest.getLstCasTest))
                {
                    CtrlCasTest.SaveFileToFolder(casTest, file);
                }
                this.Form.Dispose();
                Response.Redirect("CreerCasTest.aspx");
            }
            else
            {
                //C'est un projet
                cProjet proj = (cProjet)Session["monProjet"];

                List<CasTest> lstCtTemp = CtrlProjet.CreerLstCasTest(CtrlProjet.getLstProjetCopie);
                CtrlProjet.CreerLstFichier(lstCtTemp);
                CtrlProjet.ClonerLstCt(lstCtTemp,proj);              
                CtrlProjet.CreationFichierPhysique();


            }
            
        }



        
	}
}