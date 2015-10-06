using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texcel.Classes.Jeu
{
    class CtrlPlateforme : CtrlController
    {
        private static Plateforme plateforme = new Plateforme();

        public static int GetCount()
        {
            return context.tblPlateforme.Count();
        }



        //list des plateformes
        public static List<Plateforme> lstPlateformeJeu()
        {
            List<Plateforme> lstPlateformeJeu = new List<Plateforme>();

            foreach (Plateforme plateforme in context.tblPlateforme)
            {
                lstPlateformeJeu.Add(plateforme);
            }
            return lstPlateformeJeu;
        }

        //List des plateformes par rapport a un nom de jeu
        public static List<Plateforme> lstPlateformeJeu(string _nomJeu)
        {
            List<Plateforme> lstPlateformeJeu = new List<Plateforme>();
            cJeu jeu = CtrlJeu.GetJeu(_nomJeu);
            foreach (Plateforme plateforme in jeu.Plateforme)
            {
                lstPlateformeJeu.Add(plateforme);
            }
            return lstPlateformeJeu;
        }

        public static List<Plateforme> Rechercher()
        {
            List<Plateforme> lstPlateforme = new List<Plateforme>();
            foreach (Plateforme platforme in context.tblPlateforme)
            {
                lstPlateforme.Add(platforme);
            }
            return lstPlateforme;
        }

        public static List<Plateforme> Rechercher(string _nomTypePlateforme)
        {
            List<Plateforme> lstPlateforme = new List<Plateforme>();
            foreach (Plateforme plat in context.tblPlateforme.Where(x => x.TypePlateforme.nomTypePlateforme == _nomTypePlateforme))
            {
                lstPlateforme.Add(plat);
            }
            return lstPlateforme;
        }

        //public static void Ajouter(TypePlateforme _typePlateforme, string _nomPlateforme, string _configPlateforme, string _descPlateforme, string _sysExp)

        public static string CreerPlateforme(TypePlateforme _typePlateforme, string _nomPlateforme, string _configPlateforme, string _commPlateforme)
        {
            Plateforme plateforme = new Plateforme();
            plateforme.nomPlateforme = _nomPlateforme;
            plateforme.configPlateforme = _configPlateforme;
            plateforme.commPlateforme = _commPlateforme;
            plateforme.idTypePlateforme = _typePlateforme.idTypePlateforme;
            try
            {
                Enregistrer(plateforme);
                return "La plateforme a été ajoutée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de la Plateforme. Les données n'ont pas été enregistrées.";
            }
        }


        public static string Ajouter(TypePlateforme _typePlateforme, string _nomPlateforme, string _configPlateforme, string _descPlateforme, string _sysExp)
        {
            Plateforme plateforme = new Plateforme();
            plateforme.nomPlateforme = _nomPlateforme;
            plateforme.configPlateforme = _configPlateforme;
            plateforme.commPlateforme = _descPlateforme;
            plateforme.idTypePlateforme = _typePlateforme.idTypePlateforme;
            
            SysExp sysExp = context.tblSysExp.Where(x => x.nomSysExp == _sysExp).First(); // On va chercher le  SysExp 
            sysExp.nomSysExp = _sysExp;

            try
            {
                Enregistrer(plateforme, sysExp);
                return "La plateforme a été ajoutée et liée a un systeme d'exploitation avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de l'ajout de la Plateforme. Les données n'ont pas été enregistrées.";
            }
            
        }

        // SysExp et Plateforme existent, on veut seulement les associer
        public static string LierPlateformeSysExp(Plateforme _Plateforme, String _sysExp)
        {
            SysExp sysExp = context.tblSysExp.Where(x => x.nomSysExp == _sysExp).First();
            _Plateforme.SysExp.Add(sysExp);
            try
            {
                context.SaveChanges();
                return "Une plateforme a été liée à un systeme d'exploitation!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la liaison avec un Système d'Exploitation. Les données n'ont pas été enregistrées.";
            }
            
        }

        private static void Enregistrer(Plateforme _Plateforme, SysExp _sysExp)
        {

            context.tblPlateforme.Add(_Plateforme); // on enregistre la plateforme 
            context.SaveChanges();

            _Plateforme.SysExp.Add(_sysExp); // lier le SysExp avec la plateforme
            context.SaveChanges();

        }

        private static void Enregistrer(Plateforme _Plateforme)
        {

            context.tblPlateforme.Add(_Plateforme);
            context.SaveChanges();


        }

        // verifier si la plateforme avec le nom existe
        public static bool Verifier(string _nomPlateforme)
        {
            foreach (Plateforme p in context.tblPlateforme)
            {
                if (p.nomPlateforme == _nomPlateforme)
                {
                    return true; // plateforme existe
                }
            }
            return false; // plateforme n'existe pas
        }



        public static Plateforme GetPlateforme(string _pateforme)
        {
            Plateforme plateforme = context.tblPlateforme.Where(x => x.nomPlateforme == _pateforme).First();

            return plateforme;
        }

        // Retourne la plateforme associer au nom



        public static string Modifier(string _nomPlateforme, string _configuration, string _comm)
        {
            Plateforme plateforme = GetPlateforme(_nomPlateforme);
            plateforme.configPlateforme = _configuration;
            plateforme.commPlateforme = _comm;
            try
            {
                context.SaveChanges();
                return "La plateforme a été modifiée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la modification de la Plateforme. Les données n'ont pas été enregistrées.";
            }
        }

        public static string Supprimer(string _nomPlateforme)
        {
            context.tblPlateforme.Remove(GetPlateforme(_nomPlateforme));
            try
            {
                context.SaveChanges();
                return "La plateforme a été supprimée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression de la Plateforme. Les données n'ont pas été enregistrées.";
            }
        }

        public static string SupprimerPlaSysExp(string _nomPlateforme, string _nomSysExp)
        {
            SysExp sysExp = context.tblSysExp.Where(x => x.nomSysExp == _nomSysExp).First();
            GetPlateforme(_nomPlateforme).SysExp.Remove(sysExp);
            context.tblPlateforme.Remove(GetPlateforme(_nomPlateforme));
            try
            {
                context.SaveChanges();
                return "La plateforme associée a un système d'exploitation a été supprimée avec succès!";
            }
            catch (Exception)
            {
                return "Une erreur est survenue lors de la suppression de la Plateforme. Les données n'ont pas été supprimées.";
            }
            
        }

    }
}
