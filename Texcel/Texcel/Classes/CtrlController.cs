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
        protected static Utilisateur CurrentUtilisateur;


        public static void MessageWarnng(string _monWarning)
        {
            MessageBox.Show(_monWarning, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void SetCurrentUser(Utilisateur user)
        {
            CurrentUtilisateur = user;
        }
        public static Utilisateur GetCurrentUser()
        {
            return CurrentUtilisateur;
        }

    }
}
