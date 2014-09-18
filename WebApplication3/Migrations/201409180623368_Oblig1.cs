namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Oblig1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Bloggs", newName: "Blogger");
            RenameTable(name: "dbo.Innleggs", newName: "Innlegger");
            CreateTable(
                "dbo.Kommentarer",
                c => new
                    {
                        Kom_id = c.Int(nullable: false, identity: true),
                        Kommentar_Tittel = c.String(),
                        Kommentar_tekst = c.String(),
                        Innlegg_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Kom_id)
                .ForeignKey("dbo.Innlegger", t => t.Innlegg_Id, cascadeDelete: true)
                .Index(t => t.Innlegg_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kommentarer", "Innlegg_Id", "dbo.Innlegger");
            DropIndex("dbo.Kommentarer", new[] { "Innlegg_Id" });
            DropTable("dbo.Kommentarer");
            RenameTable(name: "dbo.Innlegger", newName: "Innleggs");
            RenameTable(name: "dbo.Blogger", newName: "Bloggs");
        }
    }
}
