﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpmonGame
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBSharpmonGameEntities : DbContext
    {
        public DBSharpmonGameEntities()
            : base("name=DBSharpmonGameEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DB_Attacks> DB_Attacks { get; set; }
        public virtual DbSet<DB_ItemsPlayer> DB_ItemsPlayer { get; set; }
        public virtual DbSet<DB_Sharpmons> DB_Sharpmons { get; set; }
    }
}
