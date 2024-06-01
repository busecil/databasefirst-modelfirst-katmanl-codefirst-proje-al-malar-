namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ogrenciDersTablosuEkleme : DbMigration
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
                        akts = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ogrenci",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KimlikNo = c.String(maxLength: 11),
                        OgrenciNo = c.String(maxLength: 11),
                        Ad = c.String(maxLength: 50),
                        Soyad = c.String(maxLength: 50),
                        DogumTarihi = c.DateTime(nullable: false),
                        Resim = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OgrenciDersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OgrenciID = c.Int(nullable: false),
                        DersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Dersler", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.Ogrenci", t => t.OgrenciID, cascadeDelete: true)
                .Index(t => t.OgrenciID)
                .Index(t => t.DersID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrenciDersler", "OgrenciID", "dbo.Ogrenci");
            DropForeignKey("dbo.OgrenciDersler", "DersID", "dbo.Dersler");
            DropIndex("dbo.OgrenciDersler", new[] { "DersID" });
            DropIndex("dbo.OgrenciDersler", new[] { "OgrenciID" });
            DropTable("dbo.Dersler");
        }
    }
}
