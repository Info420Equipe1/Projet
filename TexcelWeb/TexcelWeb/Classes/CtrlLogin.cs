using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TexcelWeb.Classes
{
    public class CtrlLogin : CtrlController
    {
        public static string VerifierLogin(string _username, string _password)
        {
            try
            {
                Utilisateur user = context.tblUtilisateur.Where(x => x.nomUtilisateur == _username).First();
                if (user.motPasse == _password)
                {
                    CtrlController.SetCurrentUser(user);
                    return "Connexion réussie!";
                }
                else
                {
                    return "Connexion échouée! Le mot de passe ne correspond pas.";
                }
            }
            catch (Exception)
            {
                return "Connexion échouée! L'utilisateur n'existe pas.";
            }
        }
    }
}