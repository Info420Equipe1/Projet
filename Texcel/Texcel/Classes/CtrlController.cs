using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Texcel.Classes
{
    class CtrlController
    {
        protected static dbProjetE1Entities context = new dbProjetE1Entities();
        protected static Utilisateur currentUtilisateur;


        public static void MessageErreur(string _monWarning)
        {
            MessageBox.Show(_monWarning, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void MessageSucces(string _monSucces)
        {
            MessageBox.Show(_monSucces, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult getDR(string _monMessage)
        {
            DialogResult monDR;
            monDR = MessageBox.Show(_monMessage, "Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return monDR;
        }

        public static void SetCurrentUser(Utilisateur user)
        {
            currentUtilisateur = user;
        }
        public static Utilisateur GetCurrentUser()
        {
            return currentUtilisateur;
        }

        public static string GetNomUtilisateur()
        {
            List<Employe> lstEmploye = new List<Employe>();
            using (context)
            {
                var query = (from s in context.tblEmploye
                             where s.noEmploye == currentUtilisateur.noEmploye
                             select s);

                foreach (var r in query)
                {
                    lstEmploye.Add(r);
                }
            }
            return lstEmploye[0].prenomEmploye + " " + lstEmploye[0].nomEmploye;
        }

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
