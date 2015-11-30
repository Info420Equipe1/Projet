using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Personnel;
using System.Drawing;

namespace TexcelWeb.Interfaces
{
    public partial class billetsTravail : System.Web.UI.Page
    {
        static Utilisateur user;
        protected void Page_Load(object sender, EventArgs e)
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
                user = CtrlController.GetCurrentUser();
                txtCurrentUserName.InnerText = user.nomUtilisateur;
                RemplirChamps();
            }
            //DataTable dT = new DataTable();
            //dT.Columns.AddRange(new DataColumn[6] { new DataColumn("Titre", typeof(string)), new DataColumn("Priorite", typeof(string)), new DataColumn("DateFin", typeof(string)), new DataColumn("TypeTest", typeof(string)), new DataColumn("Duree", typeof(string)), new DataColumn("Projet", typeof(string)) });
            //dT.Rows.Add(dT.NewRow());
            //dT.Rows[0].SetField("Titre", "No Record Available");
            //GridView1.Visible = true;
            //GridView1.DataSource = dT;
            //GridView1.DataBind();
            //GridView1.HeaderRow.Visible = true;
            //lblNbrBillet.Text = "yo";
            //lblNbrBilletPersonnel.Text = "yo";
        }

        public void RemplirChamps()
        {
            List<BilletTravail> lstBilletTravail = CtrlBilletTravail.GetLstBilletTravail(CtrlEmploye.getEmployeById(user.noEmploye.ToString()));
            DataTable dT = new DataTable();
            dT.Columns.AddRange(new DataColumn[6] { new DataColumn("Titre", typeof(string)), new DataColumn("Priorite", typeof(string)), new DataColumn("DateFin", typeof(string)), new DataColumn("TypeTest", typeof(string)), new DataColumn("Duree", typeof(string)), new DataColumn("Projet", typeof(string)) });

            if (lstBilletTravail.Count() != 0)
            {
                foreach (BilletTravail bT in lstBilletTravail)
                {
                    DataRow dR = dT.NewRow();
                    dR["Titre"] = bT.titreBilletTravail;
                    dR["Priorite"] = bT.NiveauPriorite.nomNivPri;
                    dR["DateFin"] = bT.dateFin;
                    dR["TypeTest"] = bT.CasTest.TypeTest.nomTest;
                    dR["Duree"] = bT.dureeBilletTravail;
                    dR["Projet"] = bT.CasTest.cProjet.nomProjet;
                    dT.Rows.Add(dR);
                }
	           
            }
            else
            {
                dT.Rows.Add(dT.NewRow());
                dT.Rows[0].SetField("Titre", "No Record Available");
            }

            GridView1.DataSource = dT;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowIndex == GridView1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Cliquez pour selectionner cette colonne";
                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Cliquez pour selectionner cette colonne";
            }
        }

        protected void btnCopier_Click(object sender, EventArgs e)
        {
            Session["BilletTravail"] = CtrlBilletTravail.GetBillet(GridView1.SelectedRow.Cells[0].Text);
        }
    }
}