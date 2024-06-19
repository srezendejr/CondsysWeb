namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menu : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO usuario (UsuarioId, Nome, Email, Senha, Admin, GrupoAcesso, Ativo, AlterarSenha, PessoaId) VALUES (1,'sergio rezende','sergio.rezende@outlook.com','Ao5ZnFYo344iWqv/Jr9euw==',1,2,1,0,NULL);");

        }

        public override void Down()
        {
            /**/
        }
    }
}
