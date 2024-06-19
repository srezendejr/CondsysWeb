namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LidaAvisoMorador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvisoMorador", "Lida", c => c.Boolean(nullable: false));
            DropColumn("dbo.Aviso", "Lida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aviso", "Lida", c => c.Boolean(nullable: false));
            DropColumn("dbo.AvisoMorador", "Lida");
        }
    }
}
