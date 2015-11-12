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
        //Ajouter un projet
        public static string AjouterProjet(string codeProjet, string nomProjet, string chefProjet, string dateCreationProjet, string dateLivraisonProjet, string versionJeuProjet, string descProjet, string objProjet, string DiversProjet)
        {
            cProjet projet = new cProjet();
            projet.codeProjet = codeProjet;
            projet.nomProjet = nomProjet;
            projet.chefProjet = chefProjet;
            projet.dateCreation = (Convert.ToDateTime(dateCreationProjet)).Date;
            projet.dateLivraison = (Convert.ToDateTime(dateLivraisonProjet)).Date;
            VersionJeu version = CtrlVersionJeu.GetVersionJeu(versionJeuProjet);
            projet.VersionJeu = version;
            projet.descProjet = descProjet;
            projet.objectifsProjet = objProjet;
            projet.divers = DiversProjet;
            projet.idVersionJeu = version.idVersionJeu;

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
            //Ajouter un projet dans la BD
            context.tblProjet.Add(_projet);
            context.SaveChanges();
        }
        
        //Modifier un Projet
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

        //Retourne un projet à l'aide d'un code de projet
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

        //Retourne une liste de projet pour un chef de projet specifique
        public static List<cProjet> GetListProjetChefProjet(string nomChefProjet)
        {
            List<cProjet> lstProjet = new List<cProjet>();

            foreach (cProjet proj in context.tblProjet)
            {
                if (proj.chefProjet == nomChefProjet)
                {
                    lstProjet.Add(proj);
                }
            }
            return lstProjet;
        }

        //Retourne un projet à l'aide d'un nom de projet
        public static cProjet GetProjet(string _nomProjet)
        {
            cProjet proj = context.tblProjet.Where(x => x.nomProjet == _nomProjet).First();
            return proj;
        }
        
    }
}