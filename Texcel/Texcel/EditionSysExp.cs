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
    
    public partial class EditionSysExp
    {
        public EditionSysExp()
        {
            this.VersionSysExp = new HashSet<VersionSysExp>();
        }
    
        public short idEdition { get; set; }
        public string nomEdition { get; set; }
        public short idSysExp { get; set; }
    
        public virtual SysExp SysExp { get; set; }
        public virtual ICollection<VersionSysExp> VersionSysExp { get; set; }
    }
}
