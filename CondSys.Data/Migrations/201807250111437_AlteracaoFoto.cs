namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracaoFoto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoa", "Foto", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoa", "Foto", c => c.String(maxLength: 500, unicode: false));
        }
    }
}
