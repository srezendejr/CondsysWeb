namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FotoVisitante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pessoa", "Foto", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pessoa", "Foto");
        }
    }
}
