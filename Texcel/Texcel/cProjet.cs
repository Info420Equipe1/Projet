//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Texcel
{
    using System;
    using System.Collections.Generic;
    
    public partial class cProjet
    {
        public cProjet()
        {
            this.CasTest = new HashSet<CasTest>();
        }
    
        public string codeProjet { get; set; }
        public string nomProjet { get; set; }
        public string chefProjet { get; set; }
        public string descProjet { get; set; }
        public Nullable<short> idVersionJeu { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }
        public Nullable<System.DateTime> dateLivraison { get; set; }
        public string objectifsProjet { get; set; }
        public string divers { get; set; }
    
        public virtual VersionJeu VersionJeu { get; set; }
        public virtual ICollection<CasTest> CasTest { get; set; }
    }
}
