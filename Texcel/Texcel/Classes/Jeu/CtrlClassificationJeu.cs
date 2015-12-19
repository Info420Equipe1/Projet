using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    //
    //
    //Control Classification
    //Cette classe contient toutes les méthodes et traitements en lien avec une classification.
    //
    //

    class CtrlClassificationJeu : CtrlController
    {
        //Classification Globale
        private static ClassificationJeu classificationJeu;

        //Retourne le nombre de Classification
        public static int GetCount()
        {
            return context.ClassificationJeu.Count();
        }

        //Ajout d'une Classification
        public static string Ajouter(string _nomClassification, string _codeClassification, string _descClassification)
        {
            //Nouvelle classification
            classificationJeu = new ClassificationJeu();
            classificationJeu.codeClassification = _codeClassification;
            classificationJeu.nomClassification = _nomClassification;
            classificationJeu.descClassification = _descClassification;
            try
            {
                Enregistrer(classificationJeu);
                return "La classification a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de la Classification. Les données n'ont pas été enregistrées.";
            }
        }

        //Retourne la liste de toutes les classifications de l'application
        public static List<ClassificationJeu> getListClassification()
        {
            List<ClassificationJeu> lstClassificationJeu = new List<ClassificationJeu>();
            foreach (ClassificationJeu classificationJeu in context.ClassificationJeu)
            {
                lstClassificationJeu.Add(classificationJeu);
            }
            return lstClassificationJeu;
        }

        //Retourne une Classification en fonction du Nom
        public static ClassificationJeu GetClassificationByName(string _nomClassification)
        {
            ClassificationJeu classification = context.ClassificationJeu.Where(x => x.nomClassification == _nomClassification).First();
            return classification;
        }

        //Enregistrer la Classification dans la BD
        private static void Enregistrer(ClassificationJeu _classificationJeu)
        {
            //Ajouter dans la BD
            ClassificationJeu temp = _classificationJeu;
            context.ClassificationJeu.Add(temp);
            context.SaveChanges();
        }

        //Vérifier si la classification existe a l'aide de son Nom
        public static bool VerifierClassificationJeu(string _nomClassificationJeu)
        {
            foreach (ClassificationJeu classificationJeu in context.ClassificationJeu)
            {
                if (classificationJeu.nomClassification == _nomClassificationJeu)
                {
                    return true; //True lorsque la classification existe deja
                }
            }
            return false; 
        }

        //Supprimer une Classification
        public static string Supprimer(string _nomClassification)
        {
            ClassificationJeu classificationJeu = context.ClassificationJeu.Where(x => x.nomClassification == _nomClassification).First();
            context.ClassificationJeu.Remove(classificationJeu);
            try
            {
                context.SaveChanges();
                return "La classificaiton a été supprimée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression de la Classification. Les données n'ont pas été supprimées.";
            }
        }

        //Modifier une classification
        public static string ModifierClassificationJeu(string _nomClassification, string _descClassification)
        {
            ClassificationJeu classificationJeu = context.ClassificationJeu.Where(x => x.nomClassification == _nomClassification).First();
            classificationJeu.descClassification = _descClassification;
            try
            {
                context.SaveChanges();
                return "La classification a été modifier avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification de la Classification. Les données n'ont pas été enregistrées.";
            }
        }

        //retourne une classification à l'aide du Code
        public static ClassificationJeu GetClassificationByCode(string _codeClassification)
        {
            ClassificationJeu classification = context.ClassificationJeu.Where(x => x.codeClassification == _codeClassification).First();
            return classification;
        }
    }
}
