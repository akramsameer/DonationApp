﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChairtyApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChairtyDbEntities : DbContext
    {
        public ChairtyDbEntities()
            : base("name=ChairtyDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AboutU> AboutUs { get; set; }
        public virtual DbSet<Advertise> Advertises { get; set; }
        public virtual DbSet<ContactU> ContactUs { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRule> UserRules { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Requist> Requists { get; set; }
    }
}
