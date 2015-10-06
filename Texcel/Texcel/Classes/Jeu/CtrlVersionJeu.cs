using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    class CtrlVersionJeu : CtrlController
    {
        //List des version pour un ID Donner
        public static List<VersionJeu> LstVersionJeu(int IDJeu)
        {
            List<VersionJeu> lstVersionJeu = new List<VersionJeu>();

            foreach (VersionJeu versionJeu in context.tblVersionJeu.Where(x => x.idJeu == IDJeu))
            {
                lstVersionJeu.Add(versionJeu);
            }
            return lstVersionJeu;
        }
    }
}
