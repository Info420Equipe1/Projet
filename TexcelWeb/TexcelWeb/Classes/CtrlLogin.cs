using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TexcelWeb.Classes.Personnel;

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
                    if (user.Groupe.Count == 1)
                    {
                        Groupe g = user.Groupe.First();
                        if (g.idGroupe == 4)
                        {
                            return "testeur";
                        }
                        else
                        {
                            if ((CtrlUtilisateur.VerifPremiereConn(user)) || (CtrlUtilisateur.VerifApres6Mois(user)))
                            {
                                return "changermotdepasse";
                            }
                            else
                            {
                                CtrlController.SetCurrentUser(user);
                                return "connexionreussie";
                            }
                        }
                    }
                    else
                    {
                        if ((CtrlUtilisateur.VerifPremiereConn(user)) || (CtrlUtilisateur.VerifApres6Mois(user)))
                        {
                            return "changermotdepasse";
                        }
                        else
                        {
                            CtrlController.SetCurrentUser(user);
                            return "connexionreussie";
                        }
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