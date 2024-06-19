namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CNPJConfigAreaUnidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Configuracao", "CNPJ", c => c.String(maxLength: 500, unicode: false));
            AddColumn("dbo.Unidade", "AreaTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValueSql:"0"));
            AddColumn("dbo.Unidade", "AreaTotalConstruida", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValueSql: "0"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Unidade", "AreaTotalConstruida");
            DropColumn("dbo.Unidade", "AreaTotal");
            DropColumn("dbo.Configuracao", "CNPJ");
        }
    }
}
