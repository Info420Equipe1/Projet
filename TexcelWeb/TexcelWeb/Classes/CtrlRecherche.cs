using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Test;
using System.IO;
using System.Data;

namespace TexcelWeb.Classes
{
    public class CtrlRecherche
    {
        static GridView monGV;
        static List<object> lstLigneCocher = new List<object>();
        public CtrlRecherche()
        {
           
        }

        public static void SauvegarderDonnees(GridView _monGV)
        {
            monGV = _monGV;
        }

        public static void VerifierChkBox(CheckBox _monCheckBox)
        {
            string index = _monCheckBox.ID;

        }

        

    }
}