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
    
    public partial class Plateforme
    {
        public Plateforme()
        {
            this.cJeu = new HashSet<cJeu>();
            this.SysExp = new HashSet<SysExp>();
        }
    
        public short idPlateforme { get; set; }
        public string nomPlateforme { get; set; }
        public string configPlateforme { get; set; }
        public string commPlateforme { get; set; }
        public short idTypePlateforme { get; set; }
        public string tagPlateforme { get; set; }
    
        public virtual TypePlateforme TypePlateforme { get; set; }
        public virtual ICollection<cJeu> cJeu { get; set; }
        public virtual ICollection<SysExp> SysExp { get; set; }
    }
}
