namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegracaoWhatsapp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "AccountSidWhatsApp", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Configuracao", "TokenWhatsapp", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Configuracao", "CelularContato", c => c.String(maxLength: 12, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configuracao", "CelularContato");
            DropColumn("dbo.Configuracao", "TokenWhatsapp");
            DropColumn("dbo.Configuracao", "AccountSidWhatsApp");
        }
    }
}
