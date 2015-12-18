using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Control Genre
    //Cette classe contient tous les méthodes et traitements en lien avec un Genre de jeu.
    //
    //

    class CtrlGenreJeu : CtrlController
    {
        //Genre Global
        private static GenreJeu genreJeu;

        // Obtenir le nombre d'itération dans la  table GenreJeu
        public static int GetCount()
        {
            return context.GenreJeu.Count();
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

        //Vérifier si le Genre est déjà existant à l'aide du Nom
        public static bool VerifierGenreJeu(string _GenreJeu)
        {
            foreach (GenreJeu genre in context.GenreJeu)
            {
                if (genre.nomGenre == _GenreJeu)
                {
                    return true; //True lorsque le Genre existe deja
                }
            }
            return false;
        }

        //Enregistrer un Genre dans la BD
        private static void Enregistrer(GenreJeu _genreJeu)
        {
            //Ajouter à la BD
            context.GenreJeu.Add(_genreJeu);
            context.SaveChanges();
        }

        //List de genre
        public static List<GenreJeu> LstGenreJeu()
        {
            List<GenreJeu> lstGenreJeu = new List<GenreJeu>();

            foreach (GenreJeu Genre in context.GenreJeu)
            {
                lstGenreJeu.Add(Genre);
            }
            return lstGenreJeu;
        }

        //Retourne un Genre en fonction du Nom
        public static GenreJeu GetGenreByNom(string _nomGenre)
        {
            GenreJeu Genre = context.GenreJeu.Where(x => x.nomGenre == _nomGenre).First();

            return Genre;
        }

        //Suppression d'un Genre
        public static string Supprimer(string _nomGenre)
        {
            //Supprimer un Genre
            GenreJeu Genre = context.GenreJeu.Where(x => x.nomGenre == _nomGenre).First();
            context.GenreJeu.Remove(Genre);
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

        //Modification d'un genre
        public static string ModifierGenre(string _nomGenre, string _nouveauCommentaire)
        {
            GenreJeu Genre = context.GenreJeu.Where(x => x.nomGenre == _nomGenre).First();
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
