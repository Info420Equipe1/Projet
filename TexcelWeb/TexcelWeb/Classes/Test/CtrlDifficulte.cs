﻿using System;
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

            foreach (Difficulte nivPrio in context.tblDifficulte)
            {
                lst.Add(nivPrio);
            }
            return lst;
        }

        public static Difficulte GetDiff(string _nom)
        {
            Difficulte diff = context.tblDifficulte.Where(x => x.nomDiff == _nom).First();

            return diff;
        }
    }
}