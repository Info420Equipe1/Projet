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
    
    public partial class BilletTravail
    {
        public BilletTravail()
        {
            this.Employe1 = new HashSet<Employe>();
        }
    
        public short idBilletTravail { get; set; }
        public string titreBilletTravail { get; set; }
        public Nullable<double> dureeBilletTravail { get; set; }
        public Nullable<System.DateTime> dateCreation { get; set; }
        public Nullable<System.DateTime> dateLivraison { get; set; }
        public Nullable<System.DateTime> dateFin { get; set; }
        public string descBilletTravail { get; set; }
        public Nullable<short> termine { get; set; }
        public Nullable<short> idNivPri { get; set; }
        public Nullable<short> idStatut { get; set; }
        public string noEmploye { get; set; }
        public Nullable<short> idEquipe { get; set; }
        public string codeCasTest { get; set; }
        public string tagBilletTravailPriorite { get; set; }
        public string tagBilletTravailStatut { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual Equipe Equipe { get; set; }
        public virtual CasTest CasTest { get; set; }
        public virtual NiveauPriorite NiveauPriorite { get; set; }
        public virtual Statut Statut { get; set; }
        public virtual ICollection<Employe> Employe1 { get; set; }
    }
}
