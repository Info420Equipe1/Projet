using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb
{
    public partial class creerProjet : System.Web.UI.Page
    {
<<<<<<< HEAD:TexcelWeb/TexcelWeb/Interfaces/creerProjet.aspx.cs
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (Employe Emp in CtrlUtilisateur.getLstChefProjet())
	        {
                txtChefProjetCasTest.Items.Add(Emp.nomEmploye + " " + Emp.prenomEmploye);
	        }
        }
=======
>>>>>>> origin/sprint3:TexcelWeb/TexcelWeb/creerProjet.aspx.cs
    }
}