using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class CtrlDifficulte: CtrlController
    {
        public static List<Difficulte> GetLstDiff()
        {
            List<Difficulte> lst = new List<Difficulte>();

            foreach (Difficulte nivPrio in context.Difficulte)
            {
                lst.Add(nivPrio);
            }
            return lst;
        }

        public static Difficulte GetDiff(string _nom)
        {
            Difficulte diff = context.Difficulte.Where(x => x.nomDiff == _nom).First();

            return diff;
        }

        public static Difficulte GetDiff(int _id)
        {
            Difficulte diff = context.Difficulte.Where(x => x.idDiff == _id).First();

            return diff;
        }
    }
}