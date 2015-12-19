using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes.Jeu
{
    //
    //
    //Control Version Jeu
    //Cette classe contient tous les méthodes et traitements en lien avec les versions de jeu.
    //
    //

    public class CtrlVersionJeu : CtrlController
    {
        //Retourne une version de jeu en fonction d'un nom
        public static VersionJeu GetVersionJeu(string _nomVersion)
        {
            VersionJeu Version = context.VersionJeu.Where(x => x.nomVersionJeu == _nomVersion).First();
            return Version;
        }
    }
}