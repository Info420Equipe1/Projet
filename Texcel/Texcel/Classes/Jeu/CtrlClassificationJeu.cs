using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Jeu
{
    class CtrlClassificationJeu : CtrlController
    {

        private static ClassificationJeu classificationJeu;

        public static int GetCount()
        {
            return context.tblClassificationJeu.Count();
        }

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

        public static List<ClassificationJeu> Rechercher()
        {
            List<ClassificationJeu> lstClassificationJeu = new List<ClassificationJeu>();
            foreach (ClassificationJeu classificationJeu in context.tblClassificationJeu)
            {
                lstClassificationJeu.Add(classificationJeu);
            }
            return lstClassificationJeu;
        }

        public static List<ClassificationJeu> Rechercher(string _nomClassification)
        {
            List<ClassificationJeu> lstClassificationJeu = new List<ClassificationJeu>();
            foreach (ClassificationJeu classificationJeu in context.tblClassificationJeu.Where(x => x.nomClassification == _nomClassification))
            {
                lstClassificationJeu.Add(classificationJeu);
            }
            return lstClassificationJeu;
        }

        private static void Enregistrer(ClassificationJeu _classificationJeu)
        {
            //Ajouter dans la BD
            ClassificationJeu temp = _classificationJeu;
            context.tblClassificationJeu.Add(temp);
            context.SaveChanges();
        }

        public static bool VerifierClassificationJeu(string _nomClassificationJeu)
        {
            foreach (ClassificationJeu classificationJeu in context.tblClassificationJeu)
            {
                if (classificationJeu.nomClassification == _nomClassificationJeu)
                {
                    return true; //True lorsque le theme existe deja
                }
            }
            return false; 
        }

        public static string Supprimer(string _nomClassification)
        {
            ClassificationJeu classificationJeu = context.tblClassificationJeu.Where(x => x.nomClassification == _nomClassification).First();
            context.tblClassificationJeu.Remove(classificationJeu);
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

        public static string ModifierClassificationJeu(string _nomClassification, string _descClassification)
        {
            ClassificationJeu classificationJeu = context.tblClassificationJeu.Where(x => x.nomClassification == _nomClassification).First();
            classificationJeu.descClassification = _descClassification;
            //List<cJeu> lstClassJeu = classificationJeu.Jeu.Where(x => x.idClassification == classificationJeu.idClassification).ToList();
            //foreach (cJeu jeu in lstClassJeu)
            //{
            //    jeu.ClassificationJeu.Jeu.Where(x=> x.)
            //}
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


        public static ClassificationJeu GetClassification(string _nomClassification)
        {
            ClassificationJeu classification = context.tblClassificationJeu.Where(x => x.nomClassification == _nomClassification).First();
            return classification;
        }

        //Recoit un string EX:"AO - Adultes seulement" pour retourner seulement Adultes seulement
        public static string GetClassificationName(string _nomClass)
        {
            string classNameReturn;
            switch (_nomClass)
            {
                case "AO - Adultes seulement": classNameReturn = "Adultes seulement";
                    break;
                case "E - Tous": classNameReturn = "Tous";
                    break;
                case "E10 - Tous 10 ans et plus": classNameReturn = "Tous 10 ans et plus";
                    break;
                case "EC - Jeunes Enfants": classNameReturn = "Adultes seulement";
                    break;
                case "M - Adultes": classNameReturn = "Adultes";
                    break;
                case "T - Ados": classNameReturn = "Ados";
                    break;
                default: classNameReturn = null;
                    break;
            }
            return classNameReturn;
        }
    }
}
