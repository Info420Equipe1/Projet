using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    class CtrlThemeJeu : CtrlController
    {
        private static ThemeJeu themeJeu;

        public static int GetCount()
        {
            return context.ThemeJeu.Count();
        }

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

        public static List<ThemeJeu> Rechercher(string _word)
        {
            return null;
        }

        private static void Enregistrer(ThemeJeu _themeJeu)
        {
            //Ajouter dans la BD
            context.ThemeJeu.Add(_themeJeu);
            context.SaveChanges();
        }

        //Verifier theme a laide d'un theme
        private static bool VerifierThemeJeu(ThemeJeu _ThemeJeu)
        {
            foreach (ThemeJeu theme in context.ThemeJeu)
            {
                if (theme.nomTheme == _ThemeJeu.nomTheme)
                {
                    return true; //True lorsque le theme existe deja
                }
            }
            return false; 
        }

        //verifier theme a laide d'un string
        public static bool VerifierThemeJeu(string _ThemeJeu)
        {
            foreach (ThemeJeu theme in context.ThemeJeu)
            {
                if (theme.nomTheme == _ThemeJeu)
                {
                    return true; //True lorsque le theme existe deja
                }
            }
            return false; 
        }
        //List des Themes de jeu
        public static List<ThemeJeu> LstThemeJeu()
        {
            List<ThemeJeu> lstThemeJeu = new List<ThemeJeu>();

            foreach (ThemeJeu Theme in context.ThemeJeu)
            {
                lstThemeJeu.Add(Theme);
            }
            return lstThemeJeu;
        }

        //List des Themes de jeu a laide d'un Nom de JEU
        public static List<ThemeJeu> LstThemeJeu(string _nomJeu)
        {
            List<ThemeJeu> lstThemeJeu = new List<ThemeJeu>();
            cJeu jeu = CtrlJeu.GetJeu(_nomJeu);
            foreach (ThemeJeu Theme in jeu.ThemeJeu)
            {
                lstThemeJeu.Add(Theme);
            }
            return lstThemeJeu;
        }

        //Trouver un theme a l'aide d'une string
        public static ThemeJeu GetTheme(string _nomTheme)
        {
            ThemeJeu Theme = context.ThemeJeu.Where(x => x.nomTheme == _nomTheme).First();

            return Theme;
        }

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
