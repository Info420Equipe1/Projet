//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TexcelWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            this.Groupe = new HashSet<Groupe>();
        }
    
        public string nomUtilisateur { get; set; }
        public string motPasse { get; set; }
        public int premierLogin { get; set; }
        public Nullable<System.DateTime> dateDernModif { get; set; }
        public string noEmploye { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual ICollection<Groupe> Groupe { get; set; }
    }
}
