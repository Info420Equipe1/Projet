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
    
    public partial class Employe
    {
        public Employe()
        {
            this.Equipe = new HashSet<Equipe>();
            this.cProjet = new HashSet<cProjet>();
            this.Utilisateur = new HashSet<Utilisateur>();
            this.Equipe1 = new HashSet<Equipe>();
            this.TypeTest = new HashSet<TypeTest>();
        }
    
        public string noEmploye { get; set; }
        public string prenomEmploye { get; set; }
        public string nomEmploye { get; set; }
        public string numTelPrincipal { get; set; }
        public string numTelSecondaire { get; set; }
        public string adressePostale { get; set; }
        public System.DateTime dateEmbauche { get; set; }
        public string competenceParticuliere { get; set; }
        public string tagEmploye { get; set; }
    
        public virtual ICollection<Equipe> Equipe { get; set; }
        public virtual ICollection<cProjet> cProjet { get; set; }
        public virtual ICollection<Utilisateur> Utilisateur { get; set; }
        public virtual ICollection<Equipe> Equipe1 { get; set; }
        public virtual ICollection<TypeTest> TypeTest { get; set; }
    }
}
