namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webapp1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Innleggs",
                c => new
                    {
                        Innlegg_Id = c.Int(nullable: false, identity: true),
                        Innlegg_Tittel = c.String(),
                        Innlegg_Tekst = c.String(),
                        Dato = c.DateTime(nullable: false),
                        Blogg_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Innlegg_Id)
                .ForeignKey("dbo.Bloggs", t => t.Blogg_Id, cascadeDelete: true)
                .Index(t => t.Blogg_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Innleggs", "Blogg_Id", "dbo.Bloggs");
            DropIndex("dbo.Innleggs", new[] { "Blogg_Id" });
            DropTable("dbo.Innleggs");
        }
    }
}
