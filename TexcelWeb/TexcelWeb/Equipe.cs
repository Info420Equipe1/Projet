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
    
    public partial class Equipe
    {
        public Equipe()
        {
            this.Employe1 = new HashSet<Employe>();
            this.CasTest = new HashSet<CasTest>();
        }
    
        public short idEquipe { get; set; }
        public string nomEquipe { get; set; }
        public int noChefEquipe { get; set; }
        public Nullable<short> nbTesteur { get; set; }
        public string descEquipe { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual ICollection<Employe> Employe1 { get; set; }
        public virtual ICollection<CasTest> CasTest { get; set; }
    }
}