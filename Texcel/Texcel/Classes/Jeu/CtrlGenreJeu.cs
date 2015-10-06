using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    class CtrlGenreJeu : CtrlController
    {
        private static GenreJeu genreJeu;

        //Constructeur aucun paramètre
        public CtrlGenreJeu()
        {
            genreJeu.nomGenre = null;
            genreJeu.descGenre = null;
        }

        //Constructeur avec paramètres
        public CtrlGenreJeu(string _nomGenreJeu, string _commGenre)
        {
            genreJeu.nomGenre = _nomGenreJeu;
            genreJeu.descGenre = _commGenre;
        }
        // Obtenir le nombre d'itération dans la  table GenreJeu
        public static int GetCount()
        {
            return context.tblGenreJeu.Count();
        }

        // On ajoute un nouveau GenreJeu dans la table GenreJeu
        public static string Ajouter(string _nomGenreJeu, string _commGenreJeu)
        {
            //Nouveau Genre
            genreJeu = new GenreJeu();
            genreJeu.nomGenre = _nomGenreJeu;
            genreJeu.descGenre = _commGenreJeu;
            try
            {
                Enregistrer(genreJeu);
                return "Le genre a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Genre. Les données n'ont pas été enregistrées.";
            }
        }

        private static bool VerifierGenreJeu(GenreJeu _GenreJeu)
        {
            foreach (GenreJeu genre in context.tblGenreJeu)
            {
                if (genre.nomGenre == _GenreJeu.nomGenre)
                {
                    return true; //True lorsque le Genre existe deja
                }
            }
            return false;
        }
        public static bool VerifierGenreJeu(string _GenreJeu)
        {
            foreach (GenreJeu genre in context.tblGenreJeu)
            {
                if (genre.nomGenre == _GenreJeu)
                {
                    return true; //True lorsque le Genre existe deja
                }
            }
            return false;
        }

        // Rechercher un seul GenreJeu dans la table GenreJeu
        public static List<GenreJeu> Rechercher(string _nomGenreJeu)
        {
            List<GenreJeu> lstGenreJeu = new List<GenreJeu>();;

            foreach (GenreJeu gJ in context.tblGenreJeu.Where(x => x.nomGenre == _nomGenreJeu))
            {
                lstGenreJeu.Add(context.tblGenreJeu.Where(x => x.nomGenre == gJ.nomGenre).First());
            }

            return lstGenreJeu;
        }

        private static void Enregistrer(GenreJeu _genreJeu)
        {
            //Ajouter à la BD
            context.tblGenreJeu.Add(_genreJeu);
            context.SaveChanges();
        }

        //List de genre
        public static List<GenreJeu> LstGenreJeu()
        {
            List<GenreJeu> lstGenreJeu = new List<GenreJeu>();

            foreach (GenreJeu Genre in context.tblGenreJeu)
            {
                lstGenreJeu.Add(Genre);
            }
            return lstGenreJeu;
        }

        //List de Genre par rapport à un jeu
        public static List<GenreJeu> LstGenreJeu(string _nomJeu)
        {
            List<GenreJeu> lstGenreJeu = new List<GenreJeu>();
            cJeu jeu = CtrlJeu.GetJeu(_nomJeu);
            foreach (GenreJeu Genre in jeu.GenreJeu)
            {
                lstGenreJeu.Add(Genre);
            }
            return lstGenreJeu;
        }

        public static GenreJeu GetGenre(string _nomGenre)
        {
            GenreJeu Genre = context.tblGenreJeu.Where(x => x.nomGenre == _nomGenre).First();

            return Genre;
        }

        public static string Supprimer(string _nomGenre)
        {
            //Supprimer un Genre
            GenreJeu Genre = context.tblGenreJeu.Where(x => x.nomGenre == _nomGenre).First();
            context.tblGenreJeu.Remove(Genre);
            try
            {
                context.SaveChanges();
                return "Le genre a été supprimer avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression du Genre. Les données n'ont pas été supprimées.";
            }
        }
        public static string ModifierGenre(string _nomGenre, string _nouveauCommentaire)
        {
            GenreJeu Genre = context.tblGenreJeu.Where(x => x.nomGenre == _nomGenre).First();
            Genre.descGenre = _nouveauCommentaire;
            try
            {
                context.SaveChanges();
                return "Le Genre a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification du Genre. Les données n'ont pas été enregistrées.";
            }
        }
    }
}
