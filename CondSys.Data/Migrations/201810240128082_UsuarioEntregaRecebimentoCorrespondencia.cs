namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioEntregaRecebimentoCorrespondencia : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Correspondencia", "UsuarioRecebimentoId", c => c.Int(nullable: false, defaultValueSql:"1"));
            AddColumn("dbo.Correspondencia", "UsuarioEntregaId", c => c.Int(nullable: false, defaultValueSql: "1"));
            CreateIndex("dbo.Correspondencia", "UsuarioRecebimentoId");
            CreateIndex("dbo.Correspondencia", "UsuarioEntregaId");
            AddForeignKey("dbo.Correspondencia", "UsuarioEntregaId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.Correspondencia", "UsuarioRecebimentoId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Correspondencia", "UsuarioRecebimentoId", "dbo.Usuario");
            DropForeignKey("dbo.Correspondencia", "UsuarioEntregaId", "dbo.Usuario");
            DropIndex("dbo.Correspondencia", new[] { "UsuarioEntregaId" });
            DropIndex("dbo.Correspondencia", new[] { "UsuarioRecebimentoId" });
            DropColumn("dbo.Correspondencia", "UsuarioEntregaId");
            DropColumn("dbo.Correspondencia", "UsuarioRecebimentoId");
        }
    }
}
