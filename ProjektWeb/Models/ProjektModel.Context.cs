﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjektEntities1 : DbContext
    {
        public ProjektEntities1()
            : base("name=ProjektEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Krzesła> Krzesła { get; set; }
        public virtual DbSet<Ławki> Ławki { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
    }
}