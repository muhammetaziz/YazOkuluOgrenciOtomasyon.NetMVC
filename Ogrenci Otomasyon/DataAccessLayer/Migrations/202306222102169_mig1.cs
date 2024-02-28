namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AKADEMIKPERSONELs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SICILNO = c.String(),
                        ADI = c.String(),
                        SOYADI = c.String(),
                        UNVAN = c.String(),
                        FOTOGRAFYOL = c.String(),
                        BOLUMID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BOLUMs", t => t.BOLUMID, cascadeDelete: true)
                .Index(t => t.BOLUMID);
            
            CreateTable(
                "dbo.BOLUMs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ADI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OGRENCINO = c.String(),
                        ADI = c.String(),
                        SOYADI = c.String(),
                        TCNO = c.String(),
                        BOLUMID = c.Int(nullable: false),
                        FAKULTEID = c.Int(nullable: false),
                        UNIVERSITEID = c.Int(nullable: false),
                        DANISMANID = c.Int(nullable: false),
                        AKADEMIKPERSONELs_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AKADEMIKPERSONELs", t => t.AKADEMIKPERSONELs_ID)
                .ForeignKey("dbo.BOLUMs", t => t.BOLUMID, cascadeDelete: true)
                .ForeignKey("dbo.FAKULTEs", t => t.FAKULTEID, cascadeDelete: true)
                .ForeignKey("dbo.UNIVERSITEs", t => t.UNIVERSITEID, cascadeDelete: true)
                .Index(t => t.BOLUMID)
                .Index(t => t.FAKULTEID)
                .Index(t => t.UNIVERSITEID)
                .Index(t => t.AKADEMIKPERSONELs_ID);
            
            CreateTable(
                "dbo.DERSHAREKETs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        INSERT_DATE = c.DateTime(nullable: false),
                        DANISMANID = c.Int(nullable: false),
                        OGRENCIID = c.Int(nullable: false),
                        STATE = c.Int(nullable: false),
                        UNIVERSITESTATE = c.Int(nullable: false),
                        UNIVERSITEADI = c.String(),
                        UNIVERSITEID = c.Int(nullable: false),
                        AKADEMIKPERSONELs_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AKADEMIKPERSONELs", t => t.AKADEMIKPERSONELs_ID)
                .ForeignKey("dbo.Ogrencis", t => t.OGRENCIID, cascadeDelete: true)
                .Index(t => t.OGRENCIID)
                .Index(t => t.AKADEMIKPERSONELs_ID);
            
            CreateTable(
                "dbo.DERTHAREKETDETAILS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DERSID = c.Int(nullable: false),
                        PKID = c.Int(nullable: false),
                        STATE = c.Int(nullable: false),
                        DERSHAREKETs_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DERSHAREKETs", t => t.DERSHAREKETs_ID)
                .ForeignKey("dbo.DERS", t => t.DERSID, cascadeDelete: true)
                .Index(t => t.DERSID)
                .Index(t => t.DERSHAREKETs_ID);
            
            CreateTable(
                "dbo.DERS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ADI = c.String(),
                        KREDI = c.Int(nullable: false),
                        AKTS = c.Int(nullable: false),
                        BOLUMID = c.Int(nullable: false),
                        FAKULTEID = c.Int(nullable: false),
                        AKADEMIKPERSONELID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AKADEMIKPERSONELs", t => t.AKADEMIKPERSONELID, cascadeDelete: true)
                .ForeignKey("dbo.FAKULTEs", t => t.FAKULTEID, cascadeDelete: true)
                .Index(t => t.FAKULTEID)
                .Index(t => t.AKADEMIKPERSONELID);
            
            CreateTable(
                "dbo.FAKULTEs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ADI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UNIVERSITEs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ADI = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DANISMANISLEMLERs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OGRENCIID = c.Int(nullable: false),
                        AKADEMISYENID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LOGINUSERs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        USERID = c.Int(nullable: false),
                        ROLE = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencis", "UNIVERSITEID", "dbo.UNIVERSITEs");
            DropForeignKey("dbo.DERSHAREKETs", "OGRENCIID", "dbo.Ogrencis");
            DropForeignKey("dbo.Ogrencis", "FAKULTEID", "dbo.FAKULTEs");
            DropForeignKey("dbo.DERS", "FAKULTEID", "dbo.FAKULTEs");
            DropForeignKey("dbo.DERTHAREKETDETAILS", "DERSID", "dbo.DERS");
            DropForeignKey("dbo.DERS", "AKADEMIKPERSONELID", "dbo.AKADEMIKPERSONELs");
            DropForeignKey("dbo.DERTHAREKETDETAILS", "DERSHAREKETs_ID", "dbo.DERSHAREKETs");
            DropForeignKey("dbo.DERSHAREKETs", "AKADEMIKPERSONELs_ID", "dbo.AKADEMIKPERSONELs");
            DropForeignKey("dbo.Ogrencis", "BOLUMID", "dbo.BOLUMs");
            DropForeignKey("dbo.Ogrencis", "AKADEMIKPERSONELs_ID", "dbo.AKADEMIKPERSONELs");
            DropForeignKey("dbo.AKADEMIKPERSONELs", "BOLUMID", "dbo.BOLUMs");
            DropIndex("dbo.DERS", new[] { "AKADEMIKPERSONELID" });
            DropIndex("dbo.DERS", new[] { "FAKULTEID" });
            DropIndex("dbo.DERTHAREKETDETAILS", new[] { "DERSHAREKETs_ID" });
            DropIndex("dbo.DERTHAREKETDETAILS", new[] { "DERSID" });
            DropIndex("dbo.DERSHAREKETs", new[] { "AKADEMIKPERSONELs_ID" });
            DropIndex("dbo.DERSHAREKETs", new[] { "OGRENCIID" });
            DropIndex("dbo.Ogrencis", new[] { "AKADEMIKPERSONELs_ID" });
            DropIndex("dbo.Ogrencis", new[] { "UNIVERSITEID" });
            DropIndex("dbo.Ogrencis", new[] { "FAKULTEID" });
            DropIndex("dbo.Ogrencis", new[] { "BOLUMID" });
            DropIndex("dbo.AKADEMIKPERSONELs", new[] { "BOLUMID" });
            DropTable("dbo.LOGINUSERs");
            DropTable("dbo.DANISMANISLEMLERs");
            DropTable("dbo.UNIVERSITEs");
            DropTable("dbo.FAKULTEs");
            DropTable("dbo.DERS");
            DropTable("dbo.DERTHAREKETDETAILS");
            DropTable("dbo.DERSHAREKETs");
            DropTable("dbo.Ogrencis");
            DropTable("dbo.BOLUMs");
            DropTable("dbo.AKADEMIKPERSONELs");
        }
    }
}
