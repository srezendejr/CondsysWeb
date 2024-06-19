namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoTitulo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notificacao", "Titulo", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Notificacao", "Cabecalho");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notificacao", "Cabecalho", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Notificacao", "Titulo");
        }
    }
}
