using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;
//using System.Web.UI.WebControls.ListView;

namespace TexcelWeb
{
    public partial class recherche : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             ChargerPage();

        }


        private void ChargerPage()
        {
            dDLFiltre.Items.Clear();                
            dDLFiltre.Items.Add("CasTest");
                     
        }

        protected void lvRecherche_Load(object sender, EventArgs e)
        {
           
        }

        private void initialiserLstViewRecherche()
        {
                
        }
  
       
    }
}