using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Control Type de Plateforme
    //Cette classe contient tous les méthodes et traitements en lien avec un type de plateforme.
    //
    //

    class CtrlTypePlateforme : CtrlController
    { 
        //Type de plateforme Global
        private static TypePlateforme typePlateforme;

        //Ajouter un Type de plateforme
        public static string Ajouter(string _nomTypePlateforme, string _descTypePlateforme)
        {
            typePlateforme = new TypePlateforme();
            typePlateforme.nomTypePlateforme = _nomTypePlateforme;
            typePlateforme.descTypePlateforme = _descTypePlateforme;
            try
            {
                Enregistrer(typePlateforme);
                return "Le type de plateforme a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Type de Plateforme. Les données n'ont pas été enregistrées.";
            }
        }
        
        //Retourne la liste de tous les type de plateforme
        public static List<TypePlateforme> getLstTypePlateforme()
        {
            List<TypePlateforme> lstPlateforme = new List<TypePlateforme>();
            foreach (TypePlateforme typePlat in context.TypePlateforme)
            {
                lstPlateforme.Add(typePlat);
            }
            return lstPlateforme;
        }

        //Retourne une Plateforme en fonction du Nom
        public static TypePlateforme getPlatByName(string _NomTypePlat)
        {
            TypePlateforme typePlat = context.TypePlateforme.Where(x => x.nomTypePlateforme == _NomTypePlat).First();
            return typePlat;
        }

        //Enregistrer un Type de plateforme dans la BD
        private static void Enregistrer(TypePlateforme _typePlateforme)
        {
            context.TypePlateforme.Add(typePlateforme);
            context.SaveChanges();
        }

        //Verifier si le Type de Plateforme existe dans la BD
        public static bool Verifier(string _nomPlat)
        {
            foreach (TypePlateforme typePlat in context.TypePlateforme)
            {
                if (typePlat.nomTypePlateforme == _nomPlat)
                {
                    return true;
                }
            }
            return false;
        }

        //Modifier un Type de Plateforme
        public static string Modifier(string _nomTypePlateforme, string _nouveauCommentaire)
        {
            TypePlateforme typePlat = GetTypePlateforme(_nomTypePlateforme);
            typePlat.descTypePlateforme = _nouveauCommentaire;
            try
            {
                context.SaveChanges();
                return "Le type de plateforme a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification du Type de Plateforme. Les données n'ont pas été enregistrées.";
            }
        }

        //Retourne un Type de Plateforme en fonction du nom
        public static TypePlateforme GetTypePlateforme(string _nomTypePateforme)
        {
            TypePlateforme typePlateforme = context.TypePlateforme.Where(x => x.nomTypePlateforme == _nomTypePateforme).First();

            return typePlateforme;
        }

        //Supprimer un Type de plateforme en fonction du nom
        public static string Supprimer(string _nomTypePlateforme)
        {
            context.TypePlateforme.Remove(GetTypePlateforme(_nomTypePlateforme));
            try
            {
                context.SaveChanges();
                return "Le type de plateforme a été supprimé avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression du Type de Plateforme. Les données n'ont pas été supprimées.";
            }
            
        }

    }
}
