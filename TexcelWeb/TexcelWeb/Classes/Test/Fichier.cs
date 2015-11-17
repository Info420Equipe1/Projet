using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Test
{
    public class Fichier
    {
        public string path;
        public long taille;
        public Fichier(string _path, long _taille)
        {
            path = _path;
            taille = _taille;
        }
    }
}