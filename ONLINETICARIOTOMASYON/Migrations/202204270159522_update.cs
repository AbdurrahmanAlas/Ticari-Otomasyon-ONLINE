namespace ONLINETICARIOTOMASYON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FaturaKalems", "FaturaID", "dbo.Faturalars");
            DropIndex("dbo.FaturaKalems", new[] { "FaturaID" });
            AlterColumn("dbo.FaturaKalems", "FaturaID", c => c.Int(nullable: false));
            CreateIndex("dbo.FaturaKalems", "FaturaID");
            AddForeignKey("dbo.FaturaKalems", "FaturaID", "dbo.Faturalars", "FaturaID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FaturaKalems", "FaturaID", "dbo.Faturalars");
            DropIndex("dbo.FaturaKalems", new[] { "FaturaID" });
            AlterColumn("dbo.FaturaKalems", "FaturaID", c => c.Int());
            CreateIndex("dbo.FaturaKalems", "FaturaID");
            AddForeignKey("dbo.FaturaKalems", "FaturaID", "dbo.Faturalars", "FaturaID");
        }
    }
}
