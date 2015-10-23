using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    
    class CtrlJeu : CtrlController
    {
        // private static cJeu cJeu;

        //Nombre d'itération
        public static int GetCount()
        {
            return context.tblJeu.Count();
        }

        //ajout d'un Jeu
        public static string Ajouter(string _nomJeu, string _devJeu, string _classificationJeu, string _descJeu, string _configMinJeu, List<Plateforme> _plateformeJeu, List<ThemeJeu> _themeJeu, List<GenreJeu> _genreJeu, List<VersionJeu> _versionJeu)
        {
            //Nouveau Jeu
            cJeu jeu = new cJeu();
            jeu.nomJeu = _nomJeu;
            jeu.developeur = _devJeu;
            ClassificationJeu cJeu = CtrlClassificationJeu.GetClassification(_classificationJeu);
            jeu.ClassificationJeu = cJeu;
            jeu.descJeu = _descJeu;
            jeu.configMinimal = _configMinJeu;
            jeu.Plateforme = _plateformeJeu;
            jeu.ThemeJeu = _themeJeu;
            jeu.GenreJeu = _genreJeu;
            //jeu.versionJeu = _versionJeu; La version est inexistante pour le moment

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


        public static string Modifier(string _nomJeu, string _devJeu, string _classificationJeu, string _descJeu, string _configMinJeu, List<Plateforme> _plateformeJeu, List<ThemeJeu> _themeJeu, List<GenreJeu> _genreJeu, List<VersionJeu> _versionJeu)
        {
            cJeu jeu = GetJeu(_nomJeu);
            jeu.developeur = _devJeu;
            ClassificationJeu cJeu = CtrlClassificationJeu.GetClassification(_classificationJeu);
            jeu.ClassificationJeu = cJeu;
            jeu.descJeu = _descJeu;
            jeu.configMinimal = _configMinJeu;
            jeu.Plateforme = _plateformeJeu;
            jeu.ThemeJeu = _themeJeu;
            jeu.GenreJeu = _genreJeu;
            //jeu.versionJeu = _versionJeu; La version est inexistante pour le moment

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

        //verifier jeu a laide d'un string
        public static bool VerifierJeu(string _nomJeu)
        {
            foreach (cJeu jeu in context.tblJeu)
            {
                if (jeu.nomJeu == _nomJeu)
                {
                    return true; //True lorsque le jeu existe deja
                }
            }
            return false;
        }

        private static void Enregistrer(cJeu _jeu)
        {
            //Ajouter dans la BD
            context.tblJeu.Add(_jeu);
            context.SaveChanges();
        }
        
        //List des Jeux
        public static List<cJeu> LstJeu()
        {
            List<cJeu> lstJeu = new List<cJeu>();

            foreach (cJeu jeu in context.tblJeu)
            {
                lstJeu.Add(jeu);
            }
            return lstJeu;
        }
        //Trouver un jeu a l'aide d'une string
        public static cJeu GetJeu(string _nomJeu)
        {
            cJeu Jeu = context.tblJeu.Where(x => x.nomJeu == _nomJeu).First();

            return Jeu;
        }
    }
}
