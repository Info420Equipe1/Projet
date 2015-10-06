using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    class CtrlTypePlateforme : CtrlController
    { 
        
        private static TypePlateforme typePlateforme;

        public static int GetCount()
        {
            return context.tblTypePlateforme.Count();
        }
    
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

        public static List<TypePlateforme> Rechercher()
        {
            List<TypePlateforme> lstPlateforme = new List<TypePlateforme>();
            foreach (TypePlateforme typePlat in context.tblTypePlateforme)
            {
                lstPlateforme.Add(typePlat);
            }
            return lstPlateforme;
        }

        public static List<TypePlateforme> Rechercher(string _NomTypePlat)
        {
            List<TypePlateforme> lstPlateforme = new List<TypePlateforme>();
            foreach (TypePlateforme typePlat in context.tblTypePlateforme.Where(x => x.nomTypePlateforme == _NomTypePlat))
            {
                lstPlateforme.Add(typePlat);
            }
            return lstPlateforme;
            
        }

        private static void Enregistrer(TypePlateforme _typePlateforme)
        {
            
            context.tblTypePlateforme.Add(typePlateforme);
            context.SaveChanges();
            
        }

        private static bool Verifier(TypePlateforme _typePlat)
        {
            foreach (TypePlateforme typePlat in context.tblTypePlateforme)
            {
                if (typePlat.nomTypePlateforme == _typePlat.nomTypePlateforme)
                {
                    return true; 
                }
            }
            return false; 
        }
        public static bool Verifier(string _nomPlat)
        {
            foreach (TypePlateforme typePlat in context.tblTypePlateforme)
            {
                if (typePlat.nomTypePlateforme == _nomPlat)
                {
                    return true;
                }
            }
            return false;
        }

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

        public static TypePlateforme GetTypePlateforme(string _typePateforme)
        {
            TypePlateforme typePlateforme = context.tblTypePlateforme.Where(x => x.nomTypePlateforme == _typePateforme).First();

            return typePlateforme;
        }

        public static string Supprimer(string _nomTypePlateforme)
        {
            context.tblTypePlateforme.Remove(GetTypePlateforme(_nomTypePlateforme));
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
