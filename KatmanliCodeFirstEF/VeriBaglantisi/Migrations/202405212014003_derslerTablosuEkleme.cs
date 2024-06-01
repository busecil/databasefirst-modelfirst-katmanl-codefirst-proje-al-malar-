namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class derslerTablosuEkleme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dersKodu = c.String(nullable: false, maxLength: 20),
                        dersAdi = c.String(nullable: false, maxLength: 100),
                        akts = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KimlikNo = c.String(maxLength: 11),
                        DersNo = c.String(maxLength: 11),
                        Ad = c.String(maxLength: 50),
                        Soyad = c.String(maxLength: 50),
                        DogumTarihi = c.DateTime(nullable: false),
                        Resim = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dersler");
            DropTable("dbo.Dersler");
        }
    }
}
