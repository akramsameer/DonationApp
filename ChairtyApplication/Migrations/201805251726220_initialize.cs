namespace ChairtyApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NationalId", c => c.String());
            AddColumn("dbo.AspNetUsers", "BloodType", c => c.String());
            AddColumn("dbo.AspNetUsers", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "Longitude", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreditNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreditNumber");
            DropColumn("dbo.AspNetUsers", "Longitude");
            DropColumn("dbo.AspNetUsers", "Latitude");
            DropColumn("dbo.AspNetUsers", "BloodType");
            DropColumn("dbo.AspNetUsers", "NationalId");
        }
    }
}
