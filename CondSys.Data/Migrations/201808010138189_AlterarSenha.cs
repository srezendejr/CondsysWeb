namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarSenha : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "AlterarSenha", c => c.Boolean(nullable: false, defaultValueSql:"0"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "AlterarSenha");
        }
    }
}
