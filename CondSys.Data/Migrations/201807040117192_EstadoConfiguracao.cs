namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoConfiguracao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Configuracao", "Estado", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Configuracao", "Estado", c => c.String(maxLength: 20, unicode: false));
        }
    }
}
