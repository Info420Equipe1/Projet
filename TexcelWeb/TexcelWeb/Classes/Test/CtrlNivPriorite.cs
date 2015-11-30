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
        public static NiveauPriorite getNiveauPrioriteByName(string _nomPriorite)
        {
            try
            {
                NiveauPriorite priorite = context.tblNiveauPriorite.Where(x => x.nomNivPri == _nomPriorite).First();
                return priorite;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static NiveauPriorite GetNivPrio(string _nom)
        {
            NiveauPriorite nivPrio = context.tblNiveauPriorite.Where(x => x.nomNivPri == _nom).First();

            return nivPrio;
        }

        public static NiveauPriorite GetNivPrio(int _id)
        {
            NiveauPriorite nivPrio = context.tblNiveauPriorite.Where(x => x.idNivPri == _id).First();

            return nivPrio;
        }
    }
}