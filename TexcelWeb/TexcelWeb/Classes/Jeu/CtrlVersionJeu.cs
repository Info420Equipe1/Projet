using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Jeu
{
    public class CtrlVersionJeu : CtrlController
    {
        public static VersionJeu GetVersionJeu(string _nomVersion)
        {
            VersionJeu Version = context.VersionJeu.Where(x => x.nomVersionJeu == _nomVersion).First();
            return Version;
        }
    }
}