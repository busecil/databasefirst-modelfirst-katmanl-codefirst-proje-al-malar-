namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OgrenciDersTablosuEkleme : DbMigration
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
                "dbo.OgrenciDersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OgrenciDersID = c.Int(nullable: false),
                        DersID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OgrenciDersler", t => t.DersID, cascadeDelete: true)
                .ForeignKey("dbo.OgrenciDersler", t => t.OgrenciDersID, cascadeDelete: true)
                .Index(t => t.OgrenciDersID)
                .Index(t => t.DersID);
            
            CreateTable(
                "dbo.OgrenciDersler",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KimlikNo = c.String(maxLength: 11),
                        OgrenciDersNo = c.String(maxLength: 11),
                        Ad = c.String(maxLength: 50),
                        Soyad = c.String(maxLength: 50),
                        DogumTarihi = c.DateTime(nullable: false),
                        Resim = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OgrenciDersler", "OgrenciID", "dbo.Ogrenciler");
            DropForeignKey("dbo.OgrenciDersler", "DersID", "dbo.Dersler");
            DropIndex("dbo.OgrenciDersler", new[] { "DersID" });
            DropIndex("dbo.OgrenciDersDersler", new[] { "OgrenciID" });
            DropTable("dbo.OgrenciDersler");
          
           
        }
    }
}
