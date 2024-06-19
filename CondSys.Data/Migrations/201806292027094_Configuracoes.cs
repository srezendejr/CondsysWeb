namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configuracoes : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    ALTER TABLE `db_a4abc1_sergioj`.`movimento` 
                    DROP FOREIGN KEY `FK_Movimento_Veiculo_VeiculoId`;
                    ALTER TABLE `db_a4abc1_sergioj`.`movimento` 
                    DROP INDEX `IX_VeiculoId` ;
                ");
            CreateTable(
                "dbo.Configuracao",
                c => new
                    {
                        ConfiguracaoId = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(maxLength: 100, unicode: false),
                        NomeFantasia = c.String(maxLength: 100, unicode: false),
                        TelefoneContato = c.String(maxLength: 12, unicode: false),
                        Logradouro = c.String(maxLength: 100, unicode: false),
                        Cep = c.String(maxLength: 8, unicode: false),
                        Bairro = c.String(maxLength: 50, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Estado = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        SenhaEmail = c.String(maxLength: 100, unicode: false),
                        NomeSindico = c.String(maxLength: 100, unicode: false),
                        NomeZelador = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ConfiguracaoId);
            
            AddColumn("dbo.Movimento", "PlacaVeiculo", c => c.String(maxLength: 500, unicode: false));
            DropColumn("dbo.Movimento", "VeiculoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movimento", "VeiculoId", c => c.Int());
            DropColumn("dbo.Movimento", "PlacaVeiculo");
            DropTable("dbo.Configuracao");
            CreateIndex("dbo.Movimento", "VeiculoId");
            AddForeignKey("dbo.Movimento", "VeiculoId", "dbo.Veiculo", "VeiculoId");
        }
    }
}
