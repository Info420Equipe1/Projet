using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Texcel.Classes.Personnel;

namespace Texcel.Classes
{
    class CtrlLogin : CtrlController
    {
        public static string VerifierLogin(string _username, string _password)
        {
            try
            {
                Utilisateur user = context.Utilisateur.Where(x => x.nomUtilisateur == _username).First();
                if (user.motPasse == _password)
                {
                    if ((CtrlUtilisateur.VerifPremiereConn(user))||(CtrlUtilisateur.VerifApres6Mois(user)))
                    {
                        return "Vous devez changer de mot de passe";
                    }
                    else
                    {
                        CtrlController.SetCurrentUser(user);
                        return "Connexion réussie";
                        
                    }
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
