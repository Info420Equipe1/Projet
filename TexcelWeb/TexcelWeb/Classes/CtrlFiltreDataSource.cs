using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes
{
    //
    //
    // Control Filtre Datasource
    // Cette classe contient tous les méthodes et traitements en lien la liaison des filtres de
    // recherche avec les entityDataSources
    //
    //
    
    public class CtrlFiltreDataSource : CtrlController
    {
        
        // Récupère tous les nom des filtres dans la table FiltreDataSource
        public static List<string> GetAllNomFiltre()
        {
            List<string> nomFiltres = new List<string>();
            foreach (FiltreDataSource filtreVue in context.FiltreDataSource)
            {
                nomFiltres.Add(filtreVue.nomFiltre);
            }
            return nomFiltres;
        }

        // Récupère le nom du dataSource en fonction du nom du filtre passeé en paramètre
        public static string GetDataSourceName(string _filterName)
        {
            return context.FiltreDataSource.Where(x => x.nomFiltre == _filterName).First().nomDataSource;
        }
    }
}