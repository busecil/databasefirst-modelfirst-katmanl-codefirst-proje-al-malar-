namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrenciler",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ogrenciler");
        }
    }
}
