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
    
    public partial class Difficulte
    {
        public Difficulte()
        {
            this.CasTest = new HashSet<CasTest>();
        }
    
        public short idDiff { get; set; }
        public string nomDiff { get; set; }
        public string descDiff { get; set; }
    
        public virtual ICollection<CasTest> CasTest { get; set; }
    }
}
