using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Personnel
{
    class CtrlUtilisateur : CtrlController
    {


        public static string AjouterUtilisateur(string nomUtilisateur, string MotDePasse, List<Groupe> lstGroupeUtilisateur)
        {
            //Ajout d'un nouveau Utilisateur
            Utilisateur NewUtilisateur = new Utilisateur();
            NewUtilisateur.nomUtilisateur = nomUtilisateur;
            NewUtilisateur.motPasse = MotDePasse;
            NewUtilisateur.Groupe = lstGroupeUtilisateur;

            try
            {
                Enregistrer(NewUtilisateur);
                return "L'Utilisateur a été ajouté avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de l'Utilisateur. Les données n'ont pas été enregistrées.";
            }
        }

        private static void Enregistrer(Utilisateur NewUtilisateur)
        {
            context.tblUtilisateur.Add(NewUtilisateur);
            context.SaveChanges();
        }
    }
}
