namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Corresp : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Correspondencia",
                c => new
                    {
                        CorrespondenciaId = c.Int(nullable: false, identity: true),
                        DataChegada = c.DateTime(nullable: false, precision: 0),
                        DataEntrega = c.DateTime(precision: 0),
                        Tipo = c.Int(nullable: false),
                        Mensagem = c.String(maxLength: 100, unicode: false),
                        Folha = c.String(maxLength: 30, unicode: false),
                        Entregue = c.Boolean(nullable: false),
                        MoradorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CorrespondenciaId)
                .ForeignKey("dbo.Pessoa", t => t.MoradorId, cascadeDelete: true)
                .Index(t => t.MoradorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Correspondencia");
        }
    }
}
