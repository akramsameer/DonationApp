﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChairtyApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class chairtyDbEntities : DbContext
    {
        public chairtyDbEntities()
            : base("name=chairtyDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<advertiseTbl> advertiseTbls { get; set; }
        public virtual DbSet<donationTbl> donationTbls { get; set; }
        public virtual DbSet<newsTbl> newsTbls { get; set; }
        public virtual DbSet<permissionTbl> permissionTbls { get; set; }
        public virtual DbSet<requestTbl> requestTbls { get; set; }
        public virtual DbSet<ruleTbl> ruleTbls { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<userTbl> userTbls { get; set; }
        public virtual DbSet<vediosTbl> vediosTbls { get; set; }
    }
}