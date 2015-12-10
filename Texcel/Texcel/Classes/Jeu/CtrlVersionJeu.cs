using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Texcel.Classes.Jeu
{
    class CtrlVersionJeu : CtrlController
    {
        private static VersionJeu VersionduJeu;
        //List des version pour un ID Donner
        public static List<VersionJeu> LstVersionJeu(int IDJeu)
        {
            List<VersionJeu> lstVersionJeu = new List<VersionJeu>();

            foreach (VersionJeu versionJeu in context.VersionJeu.Where(x => x.idJeu == IDJeu))
            {
                lstVersionJeu.Add(versionJeu);
            }
            return lstVersionJeu;
        }
        //List des version pour un Nom Donner
        public static List<VersionJeu> LstVersionJeu(string nomJeu)
        {
            List<VersionJeu> lstVersionJeu = new List<VersionJeu>();

            foreach (VersionJeu versionJeu in context.VersionJeu.Where(x => x.cJeu.nomJeu == nomJeu))
            {
                lstVersionJeu.Add(versionJeu);
            }
            return lstVersionJeu;
        }
        public static string Ajouter(string _NomVersion, string _Comm, string _nomJeu)
        {
            VersionduJeu = new VersionJeu();

            VersionduJeu.nomVersionJeu = _NomVersion;
            VersionduJeu.commVersionJeu = _Comm;

            cJeu _Jeu = CtrlJeu.GetJeu(_nomJeu);
            VersionduJeu.cJeu = _Jeu;

            try
            {
                Enregistrer(VersionduJeu);
                return "La version de test du jeu a été ajoutée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de la Version de test du jeu. Les données n'ont pas été enregistrées.";
            }
        }
        public static string Modifier(string _NomVersion, string _Comm, string _nomJeu)
        {
            VersionduJeu = GetVersionJeu(_NomVersion);

            VersionduJeu.commVersionJeu = _Comm;
            cJeu _Jeu = CtrlJeu.GetJeu(_nomJeu);
            VersionduJeu.cJeu = _Jeu;

            try
            {
                context.SaveChanges();
                return "La version de test du jeu a été modifiée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de la Version de test du jeu. Les données n'ont pas été enregistrées.";
            }
        }
        public static string Supprimer(string _nomVersion)
        {
            VersionJeu versionJeu = context.VersionJeu.Where(x => x.nomVersionJeu == _nomVersion).First();
            context.VersionJeu.Remove(versionJeu);
            try
            {
                context.SaveChanges();
                return "La version de test du jeu a été supprimée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression de la Version de test de jeu. Les données n'ont pas été supprimées.";
            }
        }
        private static void Enregistrer(VersionJeu _versionJeu)
        {
            //Ajouter dans la BD
            context.VersionJeu.Add(_versionJeu);
            context.SaveChanges();
        }
        public static bool VerifierVersionJeu(string _nomVersionJeu)
        {
            foreach (VersionJeu versionJeu in context.VersionJeu)
            {
                if (versionJeu.nomVersionJeu == _nomVersionJeu)
                {
                    return true; //True lorsque la version existe deja
                }
            }
            return false;
        }

        public static VersionJeu GetVersionJeu(string _nomVersion)
        {
            VersionJeu Version = context.VersionJeu.Where(x => x.nomVersionJeu == _nomVersion).First();
            return Version;
        }
    }
}
