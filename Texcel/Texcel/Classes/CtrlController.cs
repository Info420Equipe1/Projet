using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Texcel.Classes
{
    //
    //
    //Control Controller
    //Cette classe contient tous les méthodes et traitements de base pour tous les controllers
    //
    //

    class CtrlController
    {
        protected static dbProjetE1Entities context = new dbProjetE1Entities();
        protected static Utilisateur currentUtilisateur;

        // Affiche une boite de message d'erreur
        public static void MessageErreur(string _monWarning)
        {
            MessageBox.Show(_monWarning, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Affiche une boite de message de succès
        public static void MessageSucces(string _monSucces)
        {
            MessageBox.Show(_monSucces, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Crée une fenêtre avec les boutons oui et non contenant le message passé en paramètre
        // Elle retourne ensuite le choix de l'utilisateur
        public static DialogResult getDR(string _monMessage)
        {
            DialogResult monDR;
            monDR = MessageBox.Show(_monMessage, "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return monDR;
        }

        // Défini l'utiliateur actuellement connecté
        public static void SetCurrentUser(Utilisateur user)
        {
            currentUtilisateur = user;
        }

        // Récupère l'utilisateur actuellement connecté
        public static Utilisateur GetCurrentUser()
        {
            return currentUtilisateur;
        }

        // Récupère les droits associé à un groupe utilisateur
        public static List<int> GetDroits(Groupe groupeUti)
        {
            List<int> lstDroits = new List<int>();
            foreach(Forms f in groupeUti.Forms)
            {
                lstDroits.Add(f.idForm);
            }
            return lstDroits;
        }
    }
}
