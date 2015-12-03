using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Projet;

namespace TexcelWeb.Interfaces
{
    public partial class gestionBillets : System.Web.UI.Page
    {
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
                    Utilisateur currentUser = CtrlController.GetCurrentUser();
                    CtrlController.SetCurrentUser(currentUser);
                    txtCurrentUserName.InnerText = currentUser.nomUtilisateur;
                }
                ChargerPage();
            }              

        }

        private void ChargerPage()
        {
            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[7] { 
                new DataColumn("TitreBillet", typeof(string)),
                new DataColumn("Priorité", typeof(DropDownList)),
                new DataColumn("Statut", typeof(DropDownList)),
                new DataColumn("Type de Test", typeof(DropDownList)),
                new DataColumn("Durée", typeof(string)),
                new DataColumn("Testeur", typeof(DropDownList)),
                new DataColumn("CasTest", typeof(string))});
            dT.Rows.Add(dT.NewRow());
            dT.Rows[0].SetField("TitreBillet", "No Record Available");
            dgvBillets.Visible = true;
            dgvBillets.DataSource = dT;
            dgvBillets.DataBind();
            dgvBillets.HeaderRow.Visible = true;

            AfficherDdlProjetItem();           
        }
        protected void AfficherDdlProjetItem()
        {
            ddlProjet.Items.Clear();           
            CtrlGestionBillet.SaveLstProjetAffiche();

            //foreach (cProjet projet in lstProjetchefEquipe)
            //{
            //    ddlProjet.Items.Add(projet.nomProjet);
            //}

            ddlProjet.DataTextField = "nomProjet";
            ddlProjet.DataValueField = "codeProjet";
            ddlProjet.DataSource = CtrlGestionBillet.getLstProj;
            ddlProjet.DataBind();
            

        }
        protected void AfficherDdlEquipeItem(cProjet _projChoisi)
        {           
           

        }
        protected void AfficherDdlTesteurItem()
        {
            

        }

        //*****************************DROP_DOWN_LIST DU HAUT **********************************************//
        protected void ddlProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlGestionBillet.SaveProjetChoisi(ddlProjet.SelectedIndex);
        

        }
        protected void ddlEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlTesteur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //*****************************DROP_DOWN_LIST DU GRIDVIEW **********************************************//
        protected void ddlPriorite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlStatut_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTypeTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlTesteur_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //*************************************GRIDVIEW EVENT***************************************//
        protected void dgvBillets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

        }

    }
}