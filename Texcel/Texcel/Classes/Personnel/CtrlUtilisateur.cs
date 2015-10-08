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
