namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigIpMorador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "IPEntradaMorador", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Configuracao", "PortaEntradaMorador", c => c.Int(nullable: false));
            AddColumn("dbo.Configuracao", "IPSaidaMorador", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Configuracao", "PortaSaidaMorador", c => c.Int(nullable: false));
            AddColumn("dbo.Configuracao", "IPEntradaPedestre", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Configuracao", "PortaEntradaPedestre", c => c.Int(nullable: false));
            AddColumn("dbo.Configuracao", "IPSaidaPedestre", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Configuracao", "PortaSaidaPedestre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configuracao", "PortaSaidaPedestre");
            DropColumn("dbo.Configuracao", "IPSaidaPedestre");
            DropColumn("dbo.Configuracao", "PortaEntradaPedestre");
            DropColumn("dbo.Configuracao", "IPEntradaPedestre");
            DropColumn("dbo.Configuracao", "PortaSaidaMorador");
            DropColumn("dbo.Configuracao", "IPSaidaMorador");
            DropColumn("dbo.Configuracao", "PortaEntradaMorador");
            DropColumn("dbo.Configuracao", "IPEntradaMorador");
        }
    }
}
