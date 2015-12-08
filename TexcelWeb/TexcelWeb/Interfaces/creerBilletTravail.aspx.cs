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
        static bool consulterBillet;
        static Utilisateur currentUser;
        static BilletTravail billetActuel;
        static CasTest casTestCreationBillet;
        static Equipe equipeActuelle;
        protected void Page_Init(object sender, EventArgs e)
        {
            bool modifier = Convert.ToBoolean(Session["modifBillet"]);
            bool consulter = Convert.ToBoolean(Request.QueryString["consulteBillet"]);
            if (consulter)
            {
                string codeCasTest = Request.QueryString["codeCasTest"];
                //Cas de test pour info
                casTestCreationBillet = CtrlCasTest.GetCasTestByCode(codeCasTest);
            }
            if (Session["BilletTravailConsulTesteur"] != null)
            {
                BilletTravail billet = (BilletTravail)Session["BilletTravailConsulTesteur"];
                casTestCreationBillet = billet.CasTest;
                Session["BilletTravailCreationBillet"] = Session["BilletTravailConsulTesteur"];
                consulter = true;
                sidebar.Visible = false;
                main.Style.Add(HtmlTextWriterStyle.Width, "1367px");
            }
            
            modifierBillet = modifier;
            Session["modifBillet"] = false; 
            
            consulterBillet = consulter;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                
                
                if (casTestCreationBillet.Equipe.Count == 1)
	            {
                    equipeActuelle = casTestCreationBillet.Equipe.First();
	            }
                if (modifierBillet || consulterBillet)
                {
                    billetActuel = (BilletTravail)Session["BilletTravailCreationBillet"];
                }

                initializeComponent();
            }
        }

        private void initializeComponent()
        {
            //Longueur des champs
            setFieldLength();

            //Emplissage des DropDownList
            fillDropDownBox();

            //Date de terminaison cachée
            dateTerminaisonBillet.Visible = false;

            //Information du cas de test en haut de la page
            fillInformationCasTest();


            if (!modifierBillet && !consulterBillet)
            {
                //Mode creation Billet
                txtForm.InnerText = "Créer un billet";
                //Control actifs
                txtEquipe.Enabled = true;
                txtDateCreationBillet.Visible = true;
                lblDateCreation.Visible = true;
                btnEnregistrer.Visible = true;
                txtTitreBillet.Enabled = true;
                txtDureeBillet.Enabled = true;
                txtDateLivraisonBillet.Enabled = true;
                cmbTesteurBillet.Enabled = true;
                cmbPrioriteBillet.Enabled = true;
                cmbStatutBillet.Enabled = true;
                rtxtDescriptionBillet.Enabled = true;
                //Date Creation par défaut
                txtDateCreationBillet.Text = Convert.ToString(DateTime.Today.ToString("d"));
            }
            else if (modifierBillet)
            {
                //Mode modifier Billet
                txtForm.InnerText = "Modifier un billet";
                //Control actifs
                txtEquipe.Enabled = true;
                txtDateCreationBillet.Visible = true;
                lblDateCreation.Visible = true;
                btnEnregistrer.Visible = true;
                txtTitreBillet.Enabled = true;
                txtDureeBillet.Enabled = true;
                txtDateLivraisonBillet.Enabled = true;
                cmbTesteurBillet.Enabled = true;
                cmbPrioriteBillet.Enabled = true;
                cmbStatutBillet.Enabled = true;
                rtxtDescriptionBillet.Enabled = true;

                //Emplissage des champs avec le billet
                fillInformationBillet();
            }
            else
            {
                //Mode consulter billet
                txtForm.InnerText = "Consulter un billet";
                //Control actifs
                txtEquipe.Enabled = false;
                txtDateCreationBillet.Visible = false;
                lblDateCreation.Visible = false;
                btnEnregistrer.Visible = false;
                txtTitreBillet.Enabled = false;
                txtDureeBillet.Enabled = false;
                txtDateLivraisonBillet.Enabled = false;
                cmbTesteurBillet.Enabled = false;
                cmbPrioriteBillet.Enabled = false;
                cmbStatutBillet.Enabled = false;
                rtxtDescriptionBillet.Enabled = false;

                //Emplissage des champs avec le billet
                fillInformationBillet();
            }
        }


        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //Collecte de l'information pour un billet
            string titreBillet = txtTitreBillet.Text;
            string dureeBillet = txtDureeBillet.Text;
            string dateCreationBillet = String.Format("{0}", Request.Form["txtDateCreationBillet"]);
            string dateLivraisonBillet = String.Format("{0}", Request.Form["txtDateLivraisonBillet"]);
            string employeAssigneBillet = String.Format("{0}", Request.Form["cmbTesteurBillet"]);
            string statutBillet = String.Format("{0}", Request.Form["cmbStatutBillet"]);
            string prioriteBillet = String.Format("{0}", Request.Form["cmbPrioriteBillet"]);
            string dateTerminaisonBillet = String.Format("{0}", Request.Form["txtDateTerminaison"]);
            string nomCasTest = txtNomCasTest.Text;
            string descBillet= rtxtDescriptionBillet.Text;
            string nomEquipe = txtEquipe.Text;

            if (!modifierBillet)
	        {
		        //Ajout d'un billet de travail
                string message = CtrlBilletTravail.AjouterBillet(titreBillet, dureeBillet, dateCreationBillet, dateLivraisonBillet, employeAssigneBillet, statutBillet, prioriteBillet, dateTerminaisonBillet, nomCasTest, descBillet, nomEquipe);

                //Reception du message
                switch (message)
                {
                    case "billetajoute":
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Billet ajouté!', 'Le billet a été ajouté avec succès.', 'success');", true);
                        break;
                    case "erreur":
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Une erreur est survenue lors de la création du billet.', 'error');", true);
                        break;
                    case "billetExiste":
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Attention!', 'Un billet avec le même titre existe déjà.', 'warning');", true);
                        break;
                    default:
                        break;
                }
	        }
            else
            {
                //Modification d'un billet de travail
                string message = CtrlBilletTravail.ModifierBillet(billetActuel.idBilletTravail, titreBillet, dureeBillet, dateCreationBillet, dateLivraisonBillet, employeAssigneBillet, statutBillet, prioriteBillet, dateTerminaisonBillet, nomCasTest, descBillet, nomEquipe);

                //Reception du message
                switch (message)
                {
                    case "billetmodifier":
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Billet ajouté!', 'Le billet a été ajouté avec succès.', 'success');", true);
                        break;
                    case "erreur":
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Une erreur est survenue lors de la création du billet.', 'error');", true);
                        break;
                    default:
                        this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert", "swal('Oops!', 'Error 404', 'error');", true);
                        break;
                }
            }
        }

        private void setFieldLength()
        {
            //Longueur des champs
            int maxLengthTitreBillet = CtrlBilletTravail.GetMaxLength<BilletTravail>(BilletTravail => BilletTravail.titreBilletTravail);
            txtTitreBillet.MaxLength = maxLengthTitreBillet;
        }
        private void fillInformationCasTest()
        {
            //Information pour le cas de test
            txtProjetCasTest.Text = casTestCreationBillet.cProjet.nomProjet;
            txtNomCasTest.Text = casTestCreationBillet.nomCasTest;
            txtNomTypeTest.Text = casTestCreationBillet.TypeTest.nomTest;
            txtDifficulte.Text = casTestCreationBillet.Difficulte.nomDiff;
        }
        private void fillInformationBillet()
        {
            ListItem lstitem;
            txtTitreBillet.Text = billetActuel.titreBilletTravail;
            txtDureeBillet.Text = Convert.ToInt16(billetActuel.dureeBilletTravail).ToString();
            txtDateCreationBillet.Text = ((DateTime)billetActuel.dateCreation).ToShortDateString();
            if (billetActuel.dateLivraison != null)
            {
                txtDateLivraisonBillet.Text = ((DateTime)billetActuel.dateLivraison).ToShortDateString();
            }
            if (billetActuel.Employe != null)
	        {
		        lstitem = new ListItem();
                lstitem.Text = billetActuel.Employe.prenomEmploye+" "+billetActuel.Employe.nomEmploye;
                cmbTesteurBillet.SelectedIndex = cmbTesteurBillet.Items.IndexOf(lstitem);
	        }
            lstitem = new ListItem();
            lstitem.Text = billetActuel.Statut.nomStatut;
            cmbStatutBillet.SelectedIndex = cmbStatutBillet.Items.IndexOf(lstitem);
            if (billetActuel.Statut.nomStatut == "Terminé")
            {
                txtDateTerminaison.Visible = true;
                txtDateTerminaison.Text = ((DateTime)billetActuel.dateFin).ToShortDateString();
            }
            else
            {
                txtDateTerminaison.Visible = false;
            }
            lstitem = new ListItem();
            lstitem.Text = billetActuel.NiveauPriorite.nomNivPri;
            cmbPrioriteBillet.SelectedIndex = cmbPrioriteBillet.Items.IndexOf(lstitem);
            rtxtDescriptionBillet.Text = billetActuel.descBilletTravail;
        }
        private void fillDropDownBox()
        {
            ListItem lst;

            //EquipeDropDown
            txtEquipe.Items.Clear();
            lst = new ListItem();
            lst.Text = "Aucune";
            txtEquipe.Items.Add(lst);
            foreach (Equipe equipe in casTestCreationBillet.Equipe)
            {
                lst = new ListItem(equipe.nomEquipe);
                txtEquipe.Items.Add(lst);
            }

            //Emplissage du DropDownList Testeur
            if (equipeActuelle != null)
            {
                lst = new ListItem(equipeActuelle.nomEquipe);
                txtEquipe.SelectedIndex = txtEquipe.Items.IndexOf(lst);
                cmbTesteurBillet.Items.Clear();
                foreach (Employe emp in equipeActuelle.Employe1)
                {
                    cmbTesteurBillet.Items.Add(emp.prenomEmploye + " " + emp.nomEmploye);
                }
                lst = new ListItem();
                lst.Text = "Aucun";
                cmbTesteurBillet.Items.Add(lst);
                cmbTesteurBillet.SelectedIndex = cmbTesteurBillet.Items.IndexOf(lst);
                cmbTesteurBillet.Enabled = true;
            }
            else
            {
                lst = new ListItem("Aucune");
                txtEquipe.SelectedIndex = txtEquipe.Items.IndexOf(lst);
                cmbTesteurBillet.Items.Clear();
                lst = new ListItem();
                lst.Text = "Aucun";
                cmbTesteurBillet.Items.Add(lst);
                cmbTesteurBillet.SelectedIndex = cmbTesteurBillet.Items.IndexOf(lst);
                cmbTesteurBillet.Enabled = false;
            }

            //Emplissage du DropDownList Statut
            cmbStatutBillet.Items.Clear();
            foreach (Statut statut in CtrlStatut.getLstStatut())
            {
                cmbStatutBillet.Items.Add(statut.nomStatut);
            }
            lst = new ListItem();
            lst.Text = "En création";
            cmbStatutBillet.SelectedIndex = cmbStatutBillet.Items.IndexOf(lst);

            //Emplissage du drop down priorité
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

        protected void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (modifierBillet)
            {
                Session["modifBillet"] = false;
                modifierBillet = false;
                Response.Redirect("recherche.aspx");
            }
            else if (consulterBillet)
            {
                Session["consultBillet"] = false;
                consulterBillet = false;
                Response.Redirect("recherche.aspx");
                //Dla marde sa marche pas. Post back pi revien sur la meme page a cause du post back
                //ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);
            }
            else
            {
                Response.Redirect("recherche.aspx");
                //ClientScript.RegisterStartupScript(this.GetType(), "goBack", "history.go(-1);", true);
            }
        }

        protected void txtEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtEquipe.SelectedItem.Text != "Aucune")
            {
                ListItem lst;
                string nomEquipe = txtEquipe.Text;
                foreach (Equipe equipe in casTestCreationBillet.Equipe)
                {
                    if (equipe.nomEquipe == nomEquipe)
                    {
                        equipeActuelle = equipe;
                    }
                }
                cmbTesteurBillet.Enabled = true;
                cmbTesteurBillet.Items.Clear();
                foreach (Employe employe in equipeActuelle.Employe1)
                {
                    lst = new ListItem();
                    lst.Text = employe.prenomEmploye+" "+employe.nomEmploye;
                    cmbTesteurBillet.Items.Add(lst);
                }
                lst = new ListItem();
                lst.Text = "Tous";
                cmbTesteurBillet.Items.Add(lst);
                lst = new ListItem();
                lst.Text = "Aucun";
                cmbTesteurBillet.Items.Add(lst);
                cmbTesteurBillet.SelectedIndex = cmbTesteurBillet.Items.IndexOf(lst);
            }
            else
            {
                cmbTesteurBillet.Items.Clear();
                ListItem lst = new ListItem();
                lst.Text = "Aucun";
                cmbTesteurBillet.Items.Add(lst);
                cmbTesteurBillet.SelectedIndex = cmbTesteurBillet.Items.IndexOf(lst);
            }
        }
    }
}