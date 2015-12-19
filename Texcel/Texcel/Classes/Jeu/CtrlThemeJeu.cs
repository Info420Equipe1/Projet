using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Control Thème
    //Cette classe contient tous les méthodes et traitements en lien avec un Thème de jeu.
    //
    //

    class CtrlThemeJeu : CtrlController
    {
        //Thème Global
        private static ThemeJeu themeJeu;

        // Obtenir le nombre d'itération dans la  table ThemeJeu
        public static int GetCount()
        {
            return context.ThemeJeu.Count();
        }

        //Ajouter un Thème
        public static string Ajouter(string _nomThemeJeu, string _commThemeJeu)
        {
            //Nouveau Theme
            themeJeu = new ThemeJeu();
            themeJeu.nomTheme = _nomThemeJeu;
            themeJeu.commTheme = _commThemeJeu;
            try
            {
                Enregistrer(themeJeu);
                return "Le thème a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Thème. Les données n'ont pas été enregistrées.";
            }
        }

        //Enregistrer un thème dans la BD
        private static void Enregistrer(ThemeJeu _themeJeu)
        {
            //Ajouter dans la BD
            context.ThemeJeu.Add(_themeJeu);
            context.SaveChanges();
        }

        //verifier si le Theme exist en fonction du Nom
        public static bool VerifierThemeJeu(string _themeJeu)
        {
            foreach (ThemeJeu theme in context.ThemeJeu)
            {
                if (theme.nomTheme == _themeJeu)
                {
                    return true; //True lorsque le theme existe deja
                }
            }
            return false; 
        }

        //Retourne la list des Themes de jeu
        public static List<ThemeJeu> LstThemeJeu()
        {
            List<ThemeJeu> lstThemeJeu = new List<ThemeJeu>();

            foreach (ThemeJeu Theme in context.ThemeJeu)
            {
                lstThemeJeu.Add(Theme);
            }
            return lstThemeJeu;
        }

        //Retourne un Thème en fonction du Nom
        public static ThemeJeu GetThemeByNom(string _nomTheme)
        {
            ThemeJeu Theme = context.ThemeJeu.Where(x => x.nomTheme == _nomTheme).First();

            return Theme;
        }

        //Supprimer un Theme de jeu
        public static string Supprimer(string _nomTheme)
        {
            ThemeJeu Theme = context.ThemeJeu.Where(x => x.nomTheme == _nomTheme).First();
            context.ThemeJeu.Remove(Theme);
            try
            {
                context.SaveChanges();
                return "Le thème a été supprimer avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression du Thème. Les données n'ont pas été supprimées.";
            }
        }

        //Modifier un Theme de jeu
        public static string ModifierTheme(string _nomTheme, string _nouveauCommentaire)
        {
            ThemeJeu Theme = context.ThemeJeu.Where(x => x.nomTheme == _nomTheme).First();
            Theme.commTheme = _nouveauCommentaire;
            try
            {
                context.SaveChanges();
                return "Le thème a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification du Thème. Les données n'ont pas été enregistrées.";
            }
            
        }
    }
}
