using System;
using System.Windows.Forms;
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
            // .selectedvalue va etre le code du projet
            ddlProjet.DataTextField = "nomProjet";
            ddlProjet.DataValueField = "codeProjet";
            // ddlProjet.Items.Add(new ListItem(text="Choisissez un projet...");
            ddlProjet.DataSource = CtrlGestionBillet.getLstProj;        
            ddlProjet.DataBind();
            

        }
        protected void AfficherDdlEquipeItem()
        {
            ddlEquipe.Items.Clear();
            CtrlGestionBillet.SaveLstEquipeAffiche();
            // .selectedvalue va etre l'id de l'equipe
            ddlEquipe.DataTextField = "nomEquipe";
            ddlEquipe.DataValueField = "idEquipe";
            ddlEquipe.DataSource = CtrlGestionBillet.getLstEquipe;
            ddlEquipe.DataBind();
            ddlEquipe.Enabled = true;

        }
        protected void AfficherDdlTesteurItem()
        {
            ddlTesteur.Items.Clear();
            CtrlGestionBillet.SaveLstTesteurAffiche();
            // .selectedvalue va etre le no du testeur
            ddlTesteur.DataTextField = "nomEmploye";
            ddlTesteur.DataValueField = "noEmploye";
            ddlTesteur.DataSource = CtrlGestionBillet.getLstTesteur;
            ddlTesteur.DataBind();
            ddlTesteur.Enabled = true;

        }

        //*****************************DROP_DOWN_LIST DU HAUT **********************************************//
        protected void ddlProjet_SelectedIndexChanged(object sender, EventArgs e)
        {
            // enregistrer le projet qui a été sélectionné dans la classe controle
            CtrlGestionBillet.SaveProjetChoisi(ddlProjet.SelectedIndex);
            AfficherDdlEquipeItem();          

        }
        protected void ddlEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            CtrlGestionBillet.SaveEquipeChoisi(ddlEquipe.SelectedIndex);
            AfficherDdlTesteurItem();
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



        //*************************************GRIDVIEW EVENT***************************************//
        protected void dgvBillets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           

        }

    }
}