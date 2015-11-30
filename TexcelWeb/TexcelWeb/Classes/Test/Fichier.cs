using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class Fichier
    {
        public string path, extan;
        public long taille;
        public DateTime derModif;
        public Fichier(string _path, long _taille, string _extan, DateTime _derModif)
        {
            path = _path;
            taille = _taille;
            extan = _extan;
            derModif = _derModif;
        }
    }
}