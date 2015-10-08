using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Personnel
{
    class CtrlUtilisateur : CtrlController
    {


        public static string AjouterUtilisateur(string nomUtilisateur, string MotDePasse, List<Groupe> lstGroupeUtilisateur, Employe _Employe)
        {
            //Ajout d'un nouveau Utilisateur
            Utilisateur NewUtilisateur = new Utilisateur();
            NewUtilisateur.nomUtilisateur = nomUtilisateur;
            NewUtilisateur.motPasse = MotDePasse;
            NewUtilisateur.Groupe = lstGroupeUtilisateur;
            NewUtilisateur.Employe = _Employe;

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

        public static string ModifierUtilisateur(string nomUtilisateur, string MotDePasse, List<Groupe> lstGroupeUtilisateur, string nomUtilisateurAModifier)
        {
            Utilisateur UtilisateurAModifier = new Utilisateur();

            foreach (Utilisateur user in context.tblUtilisateur)
            {
                if (user.nomUtilisateur == nomUtilisateurAModifier)
                {
                    UtilisateurAModifier = user;
                }
            }
            UtilisateurAModifier.nomUtilisateur = nomUtilisateur;
            UtilisateurAModifier.motPasse = MotDePasse;
            UtilisateurAModifier.Groupe = lstGroupeUtilisateur;

            try
            {
                context.SaveChanges();
                return "L'Utilisateur a été modifié avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification de l'Utilisateur. Les données n'ont pas été enregistrées.";
            }
        }

        public static string SupprimerUtilisateur(string _NomUtilisateurASupprimer)
        {
            Utilisateur UtilisateurASupprimer = new Utilisateur();

            foreach (Utilisateur user in context.tblUtilisateur)
            {
                if (user.nomUtilisateur == _NomUtilisateurASupprimer)
                {
                    UtilisateurASupprimer = user;
                }
            }

            context.tblUtilisateur.Remove(UtilisateurASupprimer);

            try
            {
                context.SaveChanges();
                return "L'utilisateur a été supprimer avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression de l'Utilisateur. Les données n'ont pas été supprimées.";
            }
        }
        private static void Enregistrer(Utilisateur NewUtilisateur)
        {
            context.tblUtilisateur.Add(NewUtilisateur);
            context.SaveChanges();
        }

        //Liste des utilisateurs associé a un employé
        public static List<Utilisateur> lstUtilisateurAssocEmp(Employe _emp)
        {
            List<Utilisateur> lstUti = new List<Utilisateur>();

            foreach (Utilisateur uti in _emp.Utilisateur)
            {
                lstUti.Add(uti);
            }

            return lstUti;
        }

        //Trouver utilisateur par son nom d'utilisateur
        public static Utilisateur utilisateur(string _nomUti)
        {
            Utilisateur uti = context.tblUtilisateur.Where(x => x.nomUtilisateur == _nomUti).First();

            return uti;
        }

        //Liste des groupes associés a un utilisateur
        public static List<Groupe> lstGrAssUtil(Utilisateur _uti)
        {
            List<Groupe> lstGr = new List<Groupe>();

            foreach (Groupe gr in _uti.Groupe)
            {
                lstGr.Add(gr);
            }
            return lstGr;
        }
    }
}
