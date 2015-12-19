using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class CtrlDifficulte: CtrlController
    {
        //
        //
        // Control Difficulté
        // Cette classe contient tous les méthodes et traitements en lien avec la difficulté
        //
        //
        
        // Récupère la liste de tous les difficultés dans la table Difficulté
        public static List<Difficulte> GetLstDiff()
        {
            List<Difficulte> lst = new List<Difficulte>();

            foreach (Difficulte nivPrio in context.Difficulte)
            {
                lst.Add(nivPrio);
            }
            return lst;
        }

        // Récupère la difficulté en fonction du nom passé en paramètre
        public static Difficulte GetDiff(string _nom)
        {
            Difficulte diff = context.Difficulte.Where(x => x.nomDiff == _nom).First();

            return diff;
        }
    }
}