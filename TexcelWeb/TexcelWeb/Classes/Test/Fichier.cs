using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    //
    //
    //Objet fichier
    //
    //
    public class Fichier
    {
        private string path, extan;
        private long taille;
        private DateTime derModif;
        
        public string getPath
        {
            get { return path; }
        }

        public string getExtan
        {
            get { return extan; }
        }

        public long getTaille
        {
            get { return taille; }
        }

        public DateTime getDerModif
        {
            get { return derModif; }
        }
        
        public Fichier(string _path, long _taille, string _extan, DateTime _derModif)
        {
            path = _path;
            taille = _taille;
            extan = _extan;
            derModif = _derModif;
        }
    }
}