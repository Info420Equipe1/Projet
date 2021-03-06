﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TexcelWeb.Classes.Projet;
using TexcelWeb.Classes.Jeu;
using TexcelWeb.Classes.Personnel;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using TexcelWeb.Classes.Test;

namespace TexcelWeb.Classes.Projet
{
    public class CtrlProjet : CtrlController
    {

        static Dictionary<CasTest, List<FileInfo>> dictCasTestClone = new Dictionary<CasTest, List<FileInfo>>();


        public static Dictionary<CasTest, List<FileInfo>> getDictCasTestClone
        {
            get { return dictCasTestClone; }

        }
        

        //Ajouter un projet
        public static string AjouterProjet(string codeProjet, string nomProjet, string chefProjet, string dateCreationProjet, string dateLivraisonProjet, string versionJeuProjet, string descProjet, string objProjet, string DiversProjet)
        {
            if (projetExist(codeProjet))
            {
                return "projetExiste";
            }
            cProjet projet = new cProjet();
            projet.codeProjet = codeProjet;
            projet.nomProjet = nomProjet;
            if (chefProjet != "-1")
            {
                projet.chefProjet = chefProjet;
            }
            
            projet.dateCreation = (Convert.ToDateTime(dateCreationProjet)).Date;
            if (dateLivraisonProjet != "")
            {
                projet.dateLivraison = (Convert.ToDateTime(dateLivraisonProjet)).Date;
            }
            if ((versionJeuProjet != "Aucun") && (versionJeuProjet != ""))
            {
                VersionJeu version = CtrlVersionJeu.GetVersionJeu(versionJeuProjet);
                projet.VersionJeu = version;
                projet.idVersion = version.idVersionJeu;
            }
            else
            {
                projet.idVersion = null;
                projet.VersionJeu = null;
            }
            projet.descProjet = descProjet;
            projet.objProjet = objProjet;
            projet.divProjet = DiversProjet;
            


            try
            {
                Enregistrer(projet);
                return "projetajoute";
            }
            catch (Exception)
            {
                return "erreur";
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

            //if ((context.tblProjet.Contains(projet)) == true)
            //{
            //    return "AucuneModifProjet";
            //}
            projet.nomProjet = nomProjet;
            if (chefProjet != "-1")
            {
                projet.chefProjet = chefProjet;
            }
            else
            {
                projet.Employe = null;
                projet.chefProjet = null;
            }

            projet.dateCreation = Convert.ToDateTime(dateCreationProjet);

            if (dateLivraisonProjet != "")
            {
                projet.dateLivraison = Convert.ToDateTime(dateLivraisonProjet);
            }
            else
            {
                projet.dateLivraison = null;
            }
            if ((versionJeuProjet != "Aucun") && (versionJeuProjet != ""))
            {
                VersionJeu version = CtrlVersionJeu.GetVersionJeu(versionJeuProjet);
                projet.VersionJeu = version;
                projet.idVersion = version.idVersionJeu;
            }
            else
            {
                projet.idVersion = null;
                projet.VersionJeu = null;
            }
            
            projet.descProjet = descProjet;
            projet.objProjet = objProjet;
            projet.divProjet = DiversProjet;

            try
            {
                context.SaveChanges();
                return "projetmodifier";
            }
            catch (Exception)
            {
                return "erreur";
            }
        }

        //Retourne un projet à l'aide d'un code de projet
        public static cProjet getProjetByCode(string _code)
        {
            try
            {
                cProjet projet = context.tblProjet.Where(x => x.codeProjet == _code).First();
                return projet;
            }
            catch (Exception)
            {
                return null;                
            }
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
                if (proj.chefProjet != null)
                {
                    Employe chefProjet = CtrlEmploye.getEmployeById(proj.chefProjet);
                    if ((chefProjet.prenomEmploye + " " + chefProjet.nomEmploye) == nomChefProjet)
                    {
                        lstProjet.Add(proj);
                    }
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

        private static bool projetExist(string codeProjet)
        {
            foreach (cProjet projet in context.tblProjet)
            {
                if (projet.codeProjet == codeProjet)
                {
                    return true;
                }
            }
            return false;
        }

        //Retourne la longueur d'un champs
        public static int GetMaxLength<TEntity>(Expression<Func<TEntity, string>> property)
           where TEntity : cProjet
        {
            var adapter = (IObjectContextAdapter)context;
            ObjectContext objectContext = adapter.ObjectContext;

            var test = objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace);

            if (test == null)
                return -1;

            Type entType = typeof(TEntity);
            string propertyName = ((MemberExpression)property.Body).Member.Name;

            var q = test
                .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                .SelectMany(meta => ((EntityType)meta).Properties
                .Where(p => p.Name == propertyName && p.TypeUsage.EdmType.Name == "String"));

            var queryResult = q.Where(p =>
            {
                var match = p.DeclaringType.Name == entType.Name;
                if (!match)
                    match = entType.Name == p.DeclaringType.Name;

                return match;

            })
                .Select(sel => sel.TypeUsage.Facets["MaxLength"].Value)
                .ToList();

            if (queryResult.Any())
            {
                int result = Convert.ToInt32(queryResult.First());
                return result;
            }
            return -1;
        }

 
        public static Dictionary<CasTest,List<FileInfo> > ClonerLstCt(List<CasTest> _lstClone,cProjet _projetEnCours)
        {
            int CtNum = 1;
            dictCasTestClone.Clear();
            
            foreach (CasTest cT in _lstClone)
            {
                CasTest temp = new CasTest();
                temp.codeCasTest = "cT"+ _projetEnCours.codeProjet+"-" +CtNum;
                temp.codeProjet = _projetEnCours.codeProjet;
                temp.nomCasTest = cT.nomCasTest;
                temp.cProjet = _projetEnCours;
                temp.Difficulte = cT.Difficulte;
                temp.NiveauPriorite = cT.NiveauPriorite;
                temp.dateCreation = cT.dateCreation;
                temp.dateLivraison = cT.dateLivraison;
                temp.TypeTest = cT.TypeTest;
                temp.descCasTest = cT.descCasTest;
                temp.objCasTest = cT.objCasTest;
                temp.divCasTest = cT.divCasTest;
   
                dictCasTestClone.Add(temp, CtrlCasTest.GetFile(cT));
                CtNum++;
            }
            // ajouter les nouveau cas de test plus tard lorsque le client enregistre le projet
            return dictCasTestClone;
        }
       

       

       


    }
}