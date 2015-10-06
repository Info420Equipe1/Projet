using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texcel.Classes
{
    class CtrlLogin : CtrlController
    {
        public static string VerifierLogin(string _username, string _password)
        {
            try
            {
                Utilisateur user = context.tblUtilisateur.Where(x => x.nomUtilisateur == _username).First();
                if (user.motPasse == _password)
                {
                    return "Connexion réussie";
                }
                else
                {
                    return "le mot de passe ne correspond pas.";
                }
            }
            catch (Exception)
            {
                return "l'utilisateur n'existe pas.";
            }
        }
    }
}
