namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcessoMorador : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "PessoaId", c => c.Int());
            CreateIndex("dbo.Usuario", "PessoaId");
            AddForeignKey("dbo.Usuario", "PessoaId", "dbo.Pessoa", "PessoaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuario", "PessoaId", "dbo.Pessoa");
            DropIndex("dbo.Usuario", new[] { "PessoaId" });
            DropColumn("dbo.Usuario", "PessoaId");
        }
    }
}
