namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigIpVisitante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "IPEntradaVisitante", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Configuracao", "PortaEntradaVisitante", c => c.Int(nullable: false));
            AddColumn("dbo.Configuracao", "IPSaidaVisitante", c => c.String(maxLength: 15, unicode: false));
            AddColumn("dbo.Configuracao", "PortaSaidaVisitante", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Configuracao", "PortaSaidaVisitante");
            DropColumn("dbo.Configuracao", "IPSaidaVisitante");
            DropColumn("dbo.Configuracao", "PortaEntradaVisitante");
            DropColumn("dbo.Configuracao", "IPEntradaVisitante");
        }
    }
}
