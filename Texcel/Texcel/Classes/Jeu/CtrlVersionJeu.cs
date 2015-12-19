using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Texcel.Classes.Jeu
{
    //
    //
    //Control Version de jeu
    //Cette classe contient tous les méthodes et traitements en lien avec une version de jeu.
    //
    //

    class CtrlVersionJeu : CtrlController
    {
        //Objet VersionJeu global
        private static VersionJeu VersionduJeu;

        //Retourne la list des version en fonction d'un nom
        public static List<VersionJeu> LstVersionJeu(string _nomJeu)
        {
            List<VersionJeu> lstVersionJeu = new List<VersionJeu>();

            foreach (VersionJeu versionJeu in context.VersionJeu.Where(x => x.cJeu.nomJeu == _nomJeu))
            {
                lstVersionJeu.Add(versionJeu);
            }
            return lstVersionJeu;
        }

        //Ajouter une version de jeu
        public static string Ajouter(string _nomVersion, string _commVersion, string _nomJeu)
        {
            VersionduJeu = new VersionJeu();

            VersionduJeu.nomVersionJeu = _nomVersion;
            VersionduJeu.commVersionJeu = _commVersion;

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

        //Modifier une version de jeu
        public static string Modifier(string _nomVersion, string _comm, string _nomJeu)
        {
            VersionduJeu = GetVersionJeu(_nomVersion);

            VersionduJeu.commVersionJeu = _comm;
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

        //Supprimer une version de jeu
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

        //Enregistrer une version dans la BD
        private static void Enregistrer(VersionJeu _versionJeu)
        {
            context.VersionJeu.Add(_versionJeu);
            context.SaveChanges();
        }

        //Verifier si la version de jeu existe dans la BD
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

        //Retourne une Version de jeu en fonction d'un nom
        public static VersionJeu GetVersionJeu(string _nomVersion) 
        {
            VersionJeu Version = context.VersionJeu.Where(x => x.nomVersionJeu == _nomVersion).First();
            return Version;
        }

    }
}
