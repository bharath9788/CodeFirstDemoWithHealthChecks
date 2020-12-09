namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Field = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagSubjects",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Subject_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Subject_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Subject_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagSubjects", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.TagSubjects", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Subjects", "Author_Id", "dbo.Authors");
            DropIndex("dbo.TagSubjects", new[] { "Subject_Id" });
            DropIndex("dbo.TagSubjects", new[] { "Tag_Id" });
            DropIndex("dbo.Subjects", new[] { "Author_Id" });
            DropTable("dbo.TagSubjects");
            DropTable("dbo.Tags");
            DropTable("dbo.Subjects");
            DropTable("dbo.Authors");
        }
    }
}
