namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuarioCorrespondenciaNull : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    ALTER TABLE correspondencia
                    DROP FOREIGN KEY FK_Correspondencia_Usuario_UsuarioEntregaId,
                    DROP FOREIGN KEY FK_Correspondencia_Usuario_UsuarioRecebimentoId;
                    ALTER TABLE correspondencia
                    CHANGE COLUMN UsuarioRecebimentoId UsuarioRecebimentoId INT(11) NULL DEFAULT NULL ,
                    CHANGE COLUMN UsuarioEntregaId UsuarioEntregaId INT(11) NULL DEFAULT NULL ;
                    ALTER TABLE correspondencia
                    ADD CONSTRAINT FK_Correspondencia_Usuario_UsuarioEntregaId
                      FOREIGN KEY (UsuarioEntregaId)
                      REFERENCES usuario (UsuarioId),
                    ADD CONSTRAINT FK_Correspondencia_Usuario_UsuarioRecebimentoId
                      FOREIGN KEY (UsuarioRecebimentoId)
                      REFERENCES usuario (UsuarioId);");
        }
        
        public override void Down()
        {
        }
    }
}
