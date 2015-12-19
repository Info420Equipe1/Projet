using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes
{
    //
    //
    //Control Admin
    //Cette classe contient tous les méthodes et traitements en lien avec la form d'administration
    //
    //

    class CtrlAdmin : CtrlController
    {
        // Récupère les données de la vue AllSysExp
        public static System.Data.Entity.DbSet<AllSysExp> GetAllSysExpView()
        {
            return context.AllSysExp;
        }

        // Récupère les données de la vue AllPlateforme
        public static System.Data.Entity.DbSet<AllPlateforme> GetAllPlateformeView()
        {
            return context.AllPlateforme;
        }

        // Récupère les données de la table Jeu
        public static System.Data.Entity.DbSet<cJeu> GetAllJeuView()
        {
            return context.Jeu;
        }

        // Récupère les données de la vue AllEquipe
        public static System.Data.Entity.DbSet<AllEquipe> GetAllEquipeView()
        {
            return context.AllEquipe;
        }

        // Récupère les données de la table Employe
        public static System.Data.Entity.DbSet<Employe> GetAllEmployeView()
        {
            return context.Employe;
        }

        // Récupère les données de la vue AllTesteurs
        public static System.Data.Entity.DbSet<AllTesteurs> GetAllTesteursView()
        {
            return context.AllTesteurs;
        }

        // Récupère les données de la vue AllProjet
        public static System.Data.Entity.DbSet<AllProjet> GetAllProjetView()
        {
            return context.AllProjet;
        }

        // Récupère les données de la vue AllCasTest
        public static System.Data.Entity.DbSet<AllCasTest> GetAllCasTestView()
        {
            return context.AllCasTest;
        }

        // Applique les modifications fait dans le model afin de rendre l'information disponible immediatement
        public static void refreshEntity()
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }
    }
}
