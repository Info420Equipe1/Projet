using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Control Jeu
    //Cette classe contient tous les méthodes et traitements en lien avec un jeu.
    //
    //
    
    class CtrlJeu : CtrlController
    {
        //Nombre d'itération de jeu
        public static int GetCount()
        {
            return context.Jeu.Count();
        }

        //Ajout d'un Jeu
        public static string Ajouter(string _nomJeu, string _devJeu, string _classificationJeu, string _descJeu, string _configMinJeu, List<Plateforme> _plateformeJeu, List<ThemeJeu> _themeJeu, List<GenreJeu> _genreJeu, List<VersionJeu> _versionJeu)
        {
            //Nouveau Jeu avec l'information recu
            cJeu jeu = new cJeu();
            jeu.nomJeu = _nomJeu;
            jeu.developeur = _devJeu;
            ClassificationJeu cJeu = CtrlClassificationJeu.GetClassificationByCode(_classificationJeu);
            jeu.ClassificationJeu = cJeu;
            jeu.descJeu = _descJeu;
            jeu.configMinimal = _configMinJeu;
            jeu.Plateforme = _plateformeJeu;
            jeu.ThemeJeu = _themeJeu;
            jeu.GenreJeu = _genreJeu;
            jeu.VersionJeu = _versionJeu;

            try
            {
                Enregistrer(jeu);
                return "Le jeu a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Jeu. Les données n'ont pas été enregistrées.";
            }
        }

        //Modifier un Jeu
        public static string Modifier(string _nomJeu, string _devJeu, string _classificationJeu, string _descJeu, string _configMinJeu, List<Plateforme> _plateformeJeu, List<ThemeJeu> _themeJeu, List<GenreJeu> _genreJeu, List<VersionJeu> _versionJeu)
        {
            cJeu jeu = GetJeu(_nomJeu);
            jeu.developeur = _devJeu;
            ClassificationJeu cJeu = CtrlClassificationJeu.GetClassificationByCode(_classificationJeu);
            jeu.ClassificationJeu = cJeu;
            jeu.descJeu = _descJeu;
            jeu.configMinimal = _configMinJeu;
            jeu.Plateforme = _plateformeJeu;
            jeu.ThemeJeu = _themeJeu;
            jeu.GenreJeu = _genreJeu;
            jeu.VersionJeu = _versionJeu;

            try
            {
                context.SaveChanges();
                return "Le Jeu a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification du Jeu. Les données n'ont pas été enregistrées.";
            }
        }

        //Verifier si le jeu existe en fonction d'un nom
        public static bool VerifierJeu(string _nomJeu)
        {
            foreach (cJeu jeu in context.Jeu)
            {
                if (jeu.nomJeu == _nomJeu)
                {
                    return true; //True lorsque le jeu existe deja
                }
            }
            return false;
        }

        //Enregistrer un jeu dans la BD
        private static void Enregistrer(cJeu _jeu)
        {
            context.Jeu.Add(_jeu);
            context.SaveChanges();
        }
        
        //Retourne la list des Jeux
        public static List<cJeu> LstJeu()
        {
            List<cJeu> lstJeu = new List<cJeu>();

            foreach (cJeu jeu in context.Jeu)
            {
                lstJeu.Add(jeu);
            }
            return lstJeu;
        }

        //Trouver un jeu en fonction d'un nom
        public static cJeu GetJeu(string _nomJeu)
        {
            cJeu Jeu = context.Jeu.Where(x => x.nomJeu == _nomJeu).First();

            return Jeu;
        }

    }
}
