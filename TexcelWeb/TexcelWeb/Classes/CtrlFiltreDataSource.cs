﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes
{
    public class CtrlFiltreDataSource : CtrlController
    {
        public static List<string> GetAllNomFiltre()
        {
            List<string> nomFiltres = new List<string>();
            foreach (FiltreDataSource filtreVue in context.tblFiltreDataSource)
            {
                nomFiltres.Add(filtreVue.nomFiltre);
            }
            return nomFiltres;
        }

        public static string GetDataSourceName(string _filterName)
        {
            return context.tblFiltreDataSource.Where(x => x.nomFiltre == _filterName).First().nomDataSource;
        }
    }
}