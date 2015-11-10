using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Jeu;


namespace TexcelWeb.Classes.Projet
{
    public class CtrlProjet : CtrlController
    {
        public static string AjouterProjet(string codeProjet, string nomProjet, string chefProjet, string dateCreationProjet, string dateLivraisonProjet, string versionJeuProjet, string descProjet, string objProjet, string DiversProjet)
        {
            cProjet projet = new cProjet();
            projet.codeProjet = codeProjet;
            projet.nomProjet = nomProjet;
            projet.chefProjet = chefProjet;
            projet.dateCreation = Convert.ToDateTime(dateCreationProjet);
            projet.dateLivraison = Convert.ToDateTime(dateLivraisonProjet);
            VersionJeu version = CtrlVersionJeu.GetVersionJeu(versionJeuProjet);
            projet.VersionJeu = version;
            projet.descProjet = descProjet;
            projet.objectifsProjet = objProjet;
            projet.divers = DiversProjet;

            try
            {
                Enregistrer(projet);
                return "Le projet a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la création du Projet. Les données n'ont pas été enregistrées.";
            }
        }
        private static void Enregistrer(cProjet _projet)
        {
            //Ajouter dans la BD
            context.tblProjet.Add(_projet);
            context.SaveChanges();
        }

        public static string ModifierProjet(string codeProjet, string nomProjet, string chefProjet, string dateCreationProjet, string dateLivraisonProjet, string versionJeuProjet, string descProjet, string objProjet, string DiversProjet)
        {
            cProjet projet = getProjetByCode(codeProjet);
            projet.nomProjet = nomProjet;
            projet.chefProjet = chefProjet;
            projet.dateCreation = Convert.ToDateTime(dateCreationProjet);
            projet.dateLivraison = Convert.ToDateTime(dateLivraisonProjet);
            VersionJeu version = CtrlVersionJeu.GetVersionJeu(versionJeuProjet);
            projet.VersionJeu = version;
            projet.descProjet = descProjet;
            projet.objectifsProjet = objProjet;
            projet.divers = DiversProjet;

            try
            {
                context.SaveChanges();
                return "Le projet a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification du Projet. Les données n'ont pas été enregistrées.";
            }
        }

        public static cProjet getProjetByCode(string _code)
        {
            cProjet projet = context.tblProjet.Where(x => x.codeProjet == _code).First();
            return projet;
        } 
        public static List<cProjet> GetListProjet()
        {
            List<cProjet> lstProjet = new List<cProjet>();

            foreach (cProjet proj in context.tblProjet)
            {
                lstProjet.Add(proj);
            }
            return lstProjet;
        }

    }
}