using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class CtrlStatut : CtrlController
    {
        public static List<Statut> getLstStatut()
        {
            List<Statut> lstStatut = new List<Statut>();

            foreach (Statut statut in context.tblStatut)
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
                Statut statut = context.tblStatut.Where(x => x.nomStatut == _nomStatut).First();
                return statut;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}