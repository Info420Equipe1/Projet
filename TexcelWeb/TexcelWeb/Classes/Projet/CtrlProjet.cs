using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Projet;

namespace TexcelWeb.Classes.Projet
{
    public class CtrlProjet : CtrlController
    {
        public static string AjouterProjet(string codeProjet, string nomProjet, string chefProjet, string dateCreationProjet, string dateLivraisonProjet, string versionJeuProjet, string descProjet, string objProjet, string DiversProjet)
        {
            cProjet projet = new cProjet();
            projet.codeProjet = codeProjet;
            projet.nomProjet = nomProjet;
            projet.chefProjet = chefProjet;
            
            
            return "lol";
        }

        public static List<cProjet> GetListProjet()
        {
            List<cProjet> lstProjet = new List<cProjet>();

            foreach (cProjet proj in context.tblProjet)
            {
                lstProjet.Add(proj);
            }
            return lstProjet;
        }

    }
}