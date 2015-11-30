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
    }
}