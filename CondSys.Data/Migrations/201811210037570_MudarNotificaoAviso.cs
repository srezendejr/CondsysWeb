namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudarNotificaoAviso : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aviso",
                c => new
                    {
                        AvisoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Lida = c.Boolean(nullable: false),
                        Titulo = c.String(maxLength: 100, unicode: false),
                        Texto = c.String(maxLength: 5000, unicode: false),
                    })
                .PrimaryKey(t => t.AvisoId);
            
            CreateTable(
                "dbo.AvisoMorador",
                c => new
                    {
                        AvisoMoradorId = c.Int(nullable: false, identity: true),
                        MoradorId = c.Int(nullable: false),
                        AvisoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AvisoMoradorId)
                .ForeignKey("dbo.Aviso", t => t.AvisoId)
                .ForeignKey("dbo.Pessoa", t => t.MoradorId)
                .Index(t => t.MoradorId)
                .Index(t => t.AvisoId);
            
            DropTable("dbo.Notificacao");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Notificacao",
                c => new
                    {
                        NotificacaoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Lida = c.Boolean(nullable: false),
                        Titulo = c.String(maxLength: 100, unicode: false),
                        Texto = c.String(maxLength: 5000, unicode: false),
                    })
                .PrimaryKey(t => t.NotificacaoId);
            
            DropForeignKey("dbo.AvisoMorador", "MoradorId", "dbo.Pessoa");
            DropForeignKey("dbo.AvisoMorador", "AvisoId", "dbo.Aviso");
            DropIndex("dbo.AvisoMorador", new[] { "AvisoId" });
            DropIndex("dbo.AvisoMorador", new[] { "MoradorId" });
            DropTable("dbo.AvisoMorador");
            DropTable("dbo.Aviso");
        }
    }
}
