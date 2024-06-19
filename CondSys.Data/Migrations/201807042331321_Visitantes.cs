namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitantes : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "Movimento", name: "PessoaId", newName: "MoradorId");
            //RenameIndex(table: "Movimento", name: "IX_PessoaId", newName: "IX_MoradorId");

            Sql(@"ALTER TABLE `db_a4abc1_sergioj`.`movimento` 
                DROP FOREIGN KEY `FK_Movimento_Pessoa_PessoaId`;
                ALTER TABLE `db_a4abc1_sergioj`.`movimento` 
                CHANGE COLUMN `PessoaId` `MoradorId` INT(11) NOT NULL ,
                DROP INDEX `IX_PessoaId` ,
                ADD INDEX `IX_Morador` USING HASH (`MoradorId` ASC);
                ALTER TABLE `db_a4abc1_sergioj`.`movimento` 
                ADD CONSTRAINT `FK_Movimento_Pessoa_PessoaId`
                  FOREIGN KEY (`MoradorId`)
                  REFERENCES `db_a4abc1_sergioj`.`pessoa` (`PessoaId`);
                ");
            AddColumn("dbo.Pessoa", "PermiteAutorizarPortaria", c => c.Boolean(defaultValueSql: "0"));
            AddColumn("dbo.Pessoa", "PermiteAutorizarVisitante", c => c.Boolean(defaultValueSql: "0"));
            AddColumn("dbo.Pessoa", "NumeroCartao", c => c.String(maxLength: 500, unicode: false));
            AddColumn("dbo.Movimento", "VisitanteId", c => c.Int(nullable: false));
            AddColumn("dbo.Movimento", "Tipo", c => c.Int(nullable: false));
            CreateIndex("dbo.Movimento", "VisitanteId");
            AddForeignKey("dbo.Movimento", "VisitanteId", "dbo.Pessoa", "PessoaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimento", "VisitanteId", "dbo.Pessoa");
            DropIndex("dbo.Movimento", new[] { "VisitanteId" });
            DropColumn("dbo.Movimento", "Tipo");
            DropColumn("dbo.Movimento", "VisitanteId");
            DropColumn("dbo.Pessoa", "NumeroCartao");
            DropColumn("dbo.Pessoa", "PermiteAutorizarVisitante");
            DropColumn("dbo.Pessoa", "PermiteAutorizarPortaria");
            RenameIndex(table: "dbo.Movimento", name: "IX_MoradorId", newName: "IX_PessoaId");
            RenameColumn(table: "dbo.Movimento", name: "MoradorId", newName: "PessoaId");
        }
    }
}
