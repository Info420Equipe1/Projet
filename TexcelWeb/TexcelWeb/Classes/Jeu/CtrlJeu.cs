using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Jeu
{
    public class CtrlJeu : CtrlController
    {
        public static List<cJeu> LstJeu()
        {
            List<cJeu> lstJeu = new List<cJeu>();

            foreach (cJeu jeu in context.Jeu)
            {
                lstJeu.Add(jeu);
            }
            return lstJeu;
        }
        public static cJeu GetJeu(string _nomJeu)
        {
            cJeu Jeu = context.Jeu.Where(x => x.nomJeu == _nomJeu).First();

            return Jeu;
        }
    }
    
}