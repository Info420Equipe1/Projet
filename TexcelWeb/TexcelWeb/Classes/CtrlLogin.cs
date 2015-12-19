using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TexcelWeb.Classes.Personnel;

namespace TexcelWeb.Classes
{
    //
    //
    //Controle connexion
    //Cette classe contient tous les méthodes et traitements en lien avec la connexion.
    //
    //
    public class CtrlLogin : CtrlController
    {
        public static string VerifierLogin(string _username, string _password)
        {
            try
            {
                Utilisateur user = context.Utilisateur.Where(x => x.nomUtilisateur == _username).First();
                if (user.motPasse == _password)
                {
                    if ((CtrlUtilisateur.VerifPremiereConn(user)) || (CtrlUtilisateur.VerifApres6Mois(user)))
                    {
                        return "changermotdepasse";
                    }
                    else
                    {
                        Groupe g = user.Groupe.First();
                        CtrlController.SetCurrentUser(user);
                        if (g.idGroupe == 4)
                        {

                            return "testeur";
                        }
                        
                        return "connexionreussie";
                    }
                }
                else
                {
                    return "motdepasseincorrect";
                }
            }
            catch (Exception)
            {
                return "utilisateurinexistant";
            }
        }

    }
}