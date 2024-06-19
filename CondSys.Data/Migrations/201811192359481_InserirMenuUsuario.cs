namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InserirMenuUsuario : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO menu (MenuId, Nome, Nivel, MenuPaiId, Url, Icone) VALUES(1, 'Moradores', '1', NULL, 'Morador', 'person'),(2,'Unidades','1',NULL,'Unidade','home'),(3,'Usuários','1',NULL,'Usuario','supervisor_account'),(4,'Condomínio','1',NULL,'Configuracao','domain'),(5,'Visitantes','1',NULL,'Visitante','transfer_within_a_station'),(6,'Correspondencias','1',NULL,'Correspondencia','mail'),(7,'Avisos','1',NULL,'Aviso','record_voice_over');");
            Sql(@"INSERT INTO menuacesso (MenuAcessoId, MenuId, GrupoAcesso) VALUES (1,1,2),(2,2,2),(3,3,2),(4,4,2),(5,5,2),(6,6,2),(7,7,2),(8,1,4),(9,7,4);");
        }
        
        public override void Down()
        {
            /**/
        }
    }
}
