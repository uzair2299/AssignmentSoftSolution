﻿namespace AssignmentSoftSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cities", "CityName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cities", "CityName", c => c.String());
        }
    }
}
