﻿namespace video.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieComponents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberInStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}