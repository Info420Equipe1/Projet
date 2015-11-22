using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Personnel
{
    public class CtrlUtilisateur : CtrlController
    {
        public static bool VerifPremiereConn(Utilisateur _uti)
        {
            if (_uti.premierLogin == 0)
            {
                return true;
            }
            return false;
        }

        public static bool VerifApres6Mois(Utilisateur _uti)
        {

            DateTime now = DateTime.Now;
            DateTime timeAfter6 = Convert.ToDateTime(_uti.dateDernModif).AddMonths(6);
            if (now >= timeAfter6)
            {
                return true;
            }
            return false;
        }

        //Modifier mot de passe
        public static void ModifMotDePasse(Utilisateur _uti, string _motPasse)
        {
            _uti.motPasse = _motPasse;
            _uti.premierLogin = 1;
            _uti.dateDernModif = DateTime.Now;
            context.SaveChanges();
        }

        public static Utilisateur getUtilisateur(string _nomUti)
        {
            Utilisateur uti = context.tblUtilisateur.Where(x => x.nomUtilisateur == _nomUti).First();

            return uti;
        }
    }
}