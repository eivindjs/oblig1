namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class webapp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bloggs",
                c => new
                    {
                        Blogg_Id = c.Int(nullable: false, identity: true),
                        Blogg_tekst = c.String(),
                        dato = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Blogg_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bloggs");
        }
    }
}
