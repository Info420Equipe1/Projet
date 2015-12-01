using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;

namespace TexcelWeb.Classes
{
    public class CtrlController
    {
        protected static dbProjetE1Entities context = new dbProjetE1Entities();
        protected static Utilisateur currentUtilisateur;

        public static void SetCurrentUser(Utilisateur user)
        {
            currentUtilisateur = user;
        }
        public static Utilisateur GetCurrentUser()
        {
            return currentUtilisateur;
        }
        public static Utilisateur getUtilisateurByName(string nomUtilisateur)
        {
            foreach (Utilisateur user in context.tblUtilisateur)
            {
                if (user.nomUtilisateur == nomUtilisateur)
                {
                    return user;
                }
            }
            return null;
        }
        public static List<int> GetDroits(Groupe groupeUti)
        {
            List<int> lstDroits = new List<int>();
            foreach (Forms f in groupeUti.Forms)
            {
                lstDroits.Add(f.idForm);
            }
            return lstDroits;
        }

       

        
    }
}