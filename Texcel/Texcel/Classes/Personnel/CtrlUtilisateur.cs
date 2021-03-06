﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes.Personnel
{
    class CtrlUtilisateur : CtrlController
    {


        public static string AjouterUtilisateur(string _nomUtilisateur, string _motDePasse, List<Groupe> _lstGroupeUtilisateur, Employe _employe)
        {
            //Ajout d'un nouveau Utilisateur
            Utilisateur newUtilisateur = new Utilisateur();
            newUtilisateur.nomUtilisateur = _nomUtilisateur;
            newUtilisateur.motPasse = _motDePasse;
            newUtilisateur.Employe = _employe;

            //Vérifier si le aucun groupe n'est associé
            if (VerifierSiGroupeVide(_lstGroupeUtilisateur))
            {
                newUtilisateur.Groupe = _lstGroupeUtilisateur;
                try
                {
                    Enregistrer(newUtilisateur);
                    return "L'utilisateur a été ajouté avec succès!";
                }
                catch (Exception)
                {
                    return "Une erreur est survenue lors de l'ajout de l'utilisateur car le nom de cet utilisateur existe déjà. Veuillez trouver un autre nom utilisateur!";
                }
            }
            //groupe vide
            else
            {
                return "Une erreur est survenu lors de l'ajout de l'utilisateur,car vous devez associé au moins un groupe à cet utilisateur";
            }
       
        }


        public static string ModifierUtilisateur(string _nomUtilisateur, string _motDePasse, List<Groupe> _lstGroupeUtilisateur, string _nomUtilisateurAModifier)
        {
            // On assigne
            Utilisateur UtilisateurAModifier = getUtilisateur(_nomUtilisateurAModifier);
            //UtilisateurAModifier.nomUtilisateur = _nomUtilisateur;
            UtilisateurAModifier.motPasse = _motDePasse;

            //Vérifier si le aucun groupe n'est associé
            if (VerifierSiGroupeVide(_lstGroupeUtilisateur))
            {
                // on  assigne groupe à l'utilisateur
                UtilisateurAModifier.Groupe = _lstGroupeUtilisateur;
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
                //groupe vide
            else
            {
                return "Une erreur est survenu lors de l'ajout de l'utilisateur,car vous devez associé au moins un groupe à cet utilisateur";

            }
        }

        public static string SupprimerUtilisateur(string _nomUtilisateurASupprimer)
        {
            Utilisateur UtilisateurASupprimer = new Utilisateur();

            foreach (Utilisateur user in context.tblUtilisateur)
            {
                if (user.nomUtilisateur == _nomUtilisateurASupprimer)
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
        private static void Enregistrer(Utilisateur _newUtilisateur)
        {
            context.tblUtilisateur.Add(_newUtilisateur);
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
        public static Utilisateur getUtilisateur(string _nomUti)
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

        // on vérifier si le listbox de groupe est vide        
        public static bool VerifierSiGroupeVide(List<Groupe> _lstGroupeUtilisateur)
        {
            if (_lstGroupeUtilisateur.Count == 0)
            {
                return false;
            }

            return true;
        }

        //Verifie si c'est sa premiere connection
        public static bool VerifPremiereConn(Utilisateur _uti)
        {
            if (_uti.premierLogin == 0)
            {
                return true; 
            }
            return false;
        }

        public static bool VerifApres6Mois(Utilisateur _uti)
        {
            
            DateTime now = DateTime.Now;
            DateTime timeAfter6 = Convert.ToDateTime(_uti.dateDernModif).AddMonths(6);
            if (now >= timeAfter6)
            {
                return true;
            }
            return false;
        }

        //Modifier mot de passe
        public static void ModifMotDePasse(Utilisateur _uti, string _motPasse)
        {
            _uti.motPasse = _motPasse;
            _uti.premierLogin = 1;
            _uti.dateDernModif = DateTime.Now;
            context.SaveChanges();
        }
    }
}
