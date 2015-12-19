using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    //
    //
    //Control Niveau Priorité
    //Cette classe contient tous les méthodes et traitements en lien avec les niveaux de priorité.
    //
    //

    public class CtrlNivPriorite: CtrlController
    {
        //Retourne la liste de tous les niveaux de priorité de l'application
        public static List<NiveauPriorite> GetLstNivPrio()
        {
            List<NiveauPriorite> lst = new List<NiveauPriorite>();

            foreach (NiveauPriorite nivPrio in context.NiveauPriorite)
            {
                lst.Add(nivPrio);
            }
            return lst;
        }

        //Retourne un niveau de priorité en fonction d'un nom
        public static NiveauPriorite getNiveauPrioriteByName(string _nomPriorite)
        {
            try
            {
                NiveauPriorite priorite = context.NiveauPriorite.Where(x => x.nomNivPri == _nomPriorite).First();
                return priorite;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Retourne un niveau de priorité en fonction d'un ID
        public static NiveauPriorite GetNivPrio(int _id)
        {
            NiveauPriorite nivPrio = context.NiveauPriorite.Where(x => x.idNivPri == _id).First();

            return nivPrio;
        }

    }
}