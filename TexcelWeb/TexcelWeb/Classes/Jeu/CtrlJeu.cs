using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Jeu
{
    //
    //
    //Control Jeu
    //Cette classe contient tous les méthodes et traitements en lien avec les jeux
    //
    //

    public class CtrlJeu : CtrlController
    {
        //Retourne la liste de tous les Jeux de l'application
        public static List<cJeu> LstJeu()
        {
            List<cJeu> lstJeu = new List<cJeu>();

            foreach (cJeu jeu in context.Jeu)
            {
                lstJeu.Add(jeu);
            }
            return lstJeu;
        }

        //Retourne un Jeu en fonction d'un nom
        public static cJeu GetJeu(string _nomJeu)
        {
            cJeu Jeu = context.Jeu.Where(x => x.nomJeu == _nomJeu).First();

            return Jeu;
        }
    }
    
}