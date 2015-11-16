using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class CtrlNivPriorite: CtrlController
    {
        public static List<NiveauPriorite> GetLstNivPrio()
        {
            List<NiveauPriorite> lst = new List<NiveauPriorite>();

            foreach (NiveauPriorite nivPrio in context.tblNiveauPriorite)
            {
                lst.Add(nivPrio);
            }
            return lst;
        }

        public static NiveauPriorite GetNivPrio(string _nom)
        {
            NiveauPriorite nivPrio = context.tblNiveauPriorite.Where(x => x.nomNivPri == _nom).First();

            return nivPrio;
        }
    }
}