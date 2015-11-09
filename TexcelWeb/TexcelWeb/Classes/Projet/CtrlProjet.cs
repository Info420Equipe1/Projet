using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Test;
using TexcelWeb.Classes.Jeu;

namespace TexcelWeb.Classes.Test
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
            projet.VersionJeu = CtrlVersionJeu.GetVersionJeu(versionJeuProjet);
            projet.descProjet = descProjet;
            projet.objectifsProjet = objProjet;
            projet.divers = DiversProjet;

            try
            {
                Enregistrer(projet);
                return "Le projet a été ajoutée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout du Projet. Les données n'ont pas été enregistrées.";
            }
        }
        private static void Enregistrer(cProjet projet)
        {
            context.tblProjet.Add(projet);
            context.SaveChanges();
        }
    }
}