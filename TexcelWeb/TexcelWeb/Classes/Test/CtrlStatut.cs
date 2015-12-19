using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    //
    //
    //Control Statut
    //Cette classe contient tous les méthodes et traitements en lien avec les statuts.
    //
    //

    public class CtrlStatut : CtrlController
    {
        //Retourne la liste de tous les statuts de l'application
        public static List<Statut> getLstStatut()
        {
            List<Statut> lstStatut = new List<Statut>();

            foreach (Statut statut in context.Statut)
            {
                lstStatut.Add(statut);
            }
            return lstStatut;
        }

        //retourne un statut a l'aide de son Nom.
        public static Statut getStatutByName(string _nomStatut)
        {
            try
            {
                Statut statut = context.Statut.Where(x => x.nomStatut == _nomStatut).First();
                return statut;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}