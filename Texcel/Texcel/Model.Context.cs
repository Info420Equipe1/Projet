﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbProjetE1Entities : DbContext
    {
        public dbProjetE1Entities()
            : base("name=dbProjetE1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassificationJeu> tblClassificationJeu { get; set; }
        public virtual DbSet<EditionSysExp> tblEditionSysExp { get; set; }
        public virtual DbSet<GenreJeu> tblGenreJeu { get; set; }
        public virtual DbSet<cJeu> tblJeu { get; set; }
        public virtual DbSet<Plateforme> tblPlateforme { get; set; }
        public virtual DbSet<SysExp> tblSysExp { get; set; }
        public virtual DbSet<ThemeJeu> tblThemeJeu { get; set; }
        public virtual DbSet<TypePlateforme> tblTypePlateforme { get; set; }
        public virtual DbSet<VersionJeu> tblVersionJeu { get; set; }
        public virtual DbSet<VersionSysExp> tblVersionSysExp { get; set; }
        public virtual DbSet<Employe> tblEmploye { get; set; }
        public virtual DbSet<Equipe> tblEquipe { get; set; }
        public virtual DbSet<Forms> tblForms { get; set; }
        public virtual DbSet<Groupe> tblGroupe { get; set; }
        public virtual DbSet<Utilisateur> tblUtilisateur { get; set; }
        public virtual DbSet<CasTest> tblCasTest { get; set; }
        public virtual DbSet<Difficulte> tblDifficulte { get; set; }
        public virtual DbSet<NiveauPriorite> tblNiveauPriorite { get; set; }
        public virtual DbSet<cProjet> tblProjet { get; set; }
        public virtual DbSet<TypeTest> tblTypeTest { get; set; }
        public virtual DbSet<AllPlateforme> AllPlateforme { get; set; }
        public virtual DbSet<AllSysExp> AllSysExp { get; set; }
        public virtual DbSet<AllEquipe> AllEquipe { get; set; }
        public virtual DbSet<AllTesteurs> AllTesteurs { get; set; }
        public virtual DbSet<AllCasTest> AllCasTest { get; set; }
        public virtual DbSet<AllProjet> AllProjet { get; set; }
    }
}
