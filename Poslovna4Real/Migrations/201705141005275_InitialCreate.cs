namespace Poslovna4Real.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drzavas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NaseljenoMestoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PTT = c.String(),
                        Naziv = c.String(),
                        DrzavaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drzavas", t => t.DrzavaId, cascadeDelete: true)
                .Index(t => t.DrzavaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NaseljenoMestoes", "DrzavaId", "dbo.Drzavas");
            DropIndex("dbo.NaseljenoMestoes", new[] { "DrzavaId" });
            DropTable("dbo.NaseljenoMestoes");
            DropTable("dbo.Drzavas");
        }
    }
}
