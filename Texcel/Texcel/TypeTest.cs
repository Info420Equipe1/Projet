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
    
    public partial class TypeTest
    {
        public TypeTest()
        {
            this.Employe = new HashSet<Employe>();
        }
    
        public short idTest { get; set; }
        public string nomTest { get; set; }
        public string descTest { get; set; }
    
        public virtual ICollection<Employe> Employe { get; set; }
    }
}
