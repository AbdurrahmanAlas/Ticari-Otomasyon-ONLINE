namespace ONLINETICARIOTOMASYON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admın_new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admın", "KullanıcıAd", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Admın", "Sıfre", c => c.String(maxLength: 8000, unicode: false));
            AlterColumn("dbo.Admın", "Yetkı", c => c.String(maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admın", "Yetkı", c => c.String(maxLength: 10, unicode: false));
            AlterColumn("dbo.Admın", "Sıfre", c => c.String(maxLength: 30, unicode: false));
            AlterColumn("dbo.Admın", "KullanıcıAd", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
