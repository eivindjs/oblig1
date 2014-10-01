namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class oblig2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.User_id);
            
            AddColumn("dbo.Blogger", "User_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Blogger", "User_id");
            AddForeignKey("dbo.Blogger", "User_id", "dbo.Users", "User_id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogger", "User_id", "dbo.Users");
            DropIndex("dbo.Blogger", new[] { "User_id" });
            DropColumn("dbo.Blogger", "User_id");
            DropTable("dbo.Users");
        }
    }
}
