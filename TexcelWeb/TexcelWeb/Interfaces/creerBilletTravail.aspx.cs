using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb.Interfaces
{
    public partial class creerBilletTravail : System.Web.UI.Page
    {
        static bool modifierBillet;
        Utilisateur currentUser;
        protected void Page_Init(object sender, EventArgs e)
        {
            bool modifier = Convert.ToBoolean(Session["modifBillet"]);
            modifierBillet = modifier;
            Session["modifBillet"] = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initializeComponent(modifierBillet);
            }
        }

        private void initializeComponent(bool modif)
        {
            //Longueur des champs
            setFieldLength();
            //Emplissage des DropDownList
            fillDropDownBox();

            

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

            if (!modif)
            {
                //Mode creation Billet
                txtForm.InnerText = "Créer un billet";
                dateTerminaisonBillet.Visible = false;
                txtDateCreationBillet.Text = Convert.ToString(DateTime.Today.ToString("d"));
            }
            else
            {
                //Mode modifier Billet
                txtForm.InnerText = "Modifier un billet";
            }
        }

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            Session["modifBillet"] = false;
            Response.Redirect("recherche.aspx");
        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {

        }

        private void setFieldLength()
        {
            int maxLengthTitreBillet = CtrlBilletTravail.GetMaxLength<BilletTravail>(BilletTravail => BilletTravail.titreBilletTravail);
            txtTitreBillet.MaxLength = maxLengthTitreBillet;
        }
        private void fillDropDownBox()
        {
            ListItem lst;
            //Emplissage du DropDownList Chef de Projet
            cmbTesteurBillet.Items.Clear();
            foreach (Employe emp in CtrlEmploye.getLstTesteur())
            {
                cmbTesteurBillet.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
            }
            lst = new ListItem();
            lst.Text = "Aucun";
            cmbTesteurBillet.Items.Add(lst);
            cmbTesteurBillet.SelectedIndex = cmbTesteurBillet.Items.IndexOf(lst);

            //Emplissage du DropDownList Jeux
            cmbStatutBillet.Items.Clear();
            foreach (Statut statut in CtrlStatut.getLstStatut())
            {
                cmbStatutBillet.Items.Add(statut.nomStatut);
            }
            lst = new ListItem();
            lst.Text = "En création";
            cmbStatutBillet.SelectedIndex = cmbStatutBillet.Items.IndexOf(lst);

            cmbPrioriteBillet.Items.Clear();
            foreach (NiveauPriorite niveauPrio in CtrlNivPriorite.GetLstNivPrio())
            {
                cmbPrioriteBillet.Items.Add(niveauPrio.nomNivPri);
            }
            lst = new ListItem();
            lst.Text = "Normale";
            cmbPrioriteBillet.SelectedIndex = cmbPrioriteBillet.Items.IndexOf(lst);
        }

        protected void cmbStatutBillet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatutBillet.SelectedItem.Text == "Terminé")
            {
                dateTerminaisonBillet.Visible = true;
            }
            else
            {
                dateTerminaisonBillet.Visible = false;
            }
        }
    }
}