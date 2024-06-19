namespace CondSys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 500, unicode: false),
                        Nivel = c.String(maxLength: 500, unicode: false),
                        MenuPaiId = c.Int(),
                        Url = c.String(maxLength: 500, unicode: false),
                        Icone = c.String(maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.MenuId);
            
            CreateTable(
                "dbo.MenuAcesso",
                c => new
                    {
                        MenuAcessoId = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(nullable: false),
                        GrupoAcesso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuAcessoId)
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MenuId);
            
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        PessoaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        NomeSocial = c.String(maxLength: 500, unicode: false),
                        DataNascimento = c.DateTime(nullable: false, precision: 0),
                        Genero = c.Int(nullable: false),
                        Profissao = c.String(maxLength: 40, unicode: false),
                        Ativo = c.Boolean(nullable: false),
                        ProprietarioMorador = c.Boolean(nullable: false),
                        Tipo = c.Int(nullable: false),
                        TipoPessoaMovimento = c.Int(nullable: false),
                        UnidadeId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.PessoaId)
                .ForeignKey("dbo.Unidade", t => t.UnidadeId)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.PessoaContato",
                c => new
                    {
                        PessoaContatoId = c.Int(nullable: false, identity: true),
                        Contato = c.String(maxLength: 150, unicode: false),
                        Tipo = c.Int(nullable: false),
                        PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.PessoaContatoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.PessoaDocumento",
                c => new
                    {
                        PessoaDocumentoId = c.Int(nullable: false, identity: true),
                        Documento = c.String(maxLength: 500, unicode: false),
                        Tipo = c.Int(nullable: false),
                        PessoaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PessoaDocumentoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId, cascadeDelete: true)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.PessoaEndereco",
                c => new
                    {
                        PessoaEnderecoId = c.Int(nullable: false, identity: true),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Cep = c.String(maxLength: 8, unicode: false),
                        Complemento = c.String(maxLength: 30, unicode: false),
                        Bairro = c.String(maxLength: 30, unicode: false),
                        Nro = c.String(maxLength: 500, unicode: false),
                        CidadeId = c.Int(nullable: false),
                        PessoaId = c.Int(),
                    })
                .PrimaryKey(t => t.PessoaEnderecoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .Index(t => t.PessoaId);
            
            CreateTable(
                "dbo.Unidade",
                c => new
                    {
                        UnidadeId = c.Int(nullable: false, identity: true),
                        Numero = c.String(maxLength: 500, unicode: false),
                        Localizacao = c.String(maxLength: 500, unicode: false),
                        Bloco = c.String(maxLength: 10, unicode: false),
                        Andar = c.String(maxLength: 10, unicode: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UnidadeId);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        VeiculoId = c.Int(nullable: false, identity: true),
                        Placa = c.String(maxLength: 500, unicode: false),
                        Modelo = c.String(maxLength: 500, unicode: false),
                        Marca = c.String(maxLength: 500, unicode: false),
                        Cor = c.String(maxLength: 500, unicode: false),
                        UnidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VeiculoId)
                .ForeignKey("dbo.Unidade", t => t.UnidadeId, cascadeDelete: true)
                .Index(t => t.UnidadeId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                        Admin = c.Boolean(nullable: false),
                        GrupoAcesso = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Movimento",
                c => new
                    {
                        MovimentoId = c.Int(nullable: false, identity: true),
                        DataHoraEntrada = c.DateTime(nullable: false, precision: 0),
                        DataHoraSaida = c.DateTime(nullable: false, precision: 0),
                        NroCartao = c.String(maxLength: 500, unicode: false),
                        PessoaId = c.Int(nullable: false),
                        VeiculoId = c.Int(),
                    })
                .PrimaryKey(t => t.MovimentoId)
                .ForeignKey("dbo.Pessoa", t => t.PessoaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .Index(t => t.PessoaId)
                .Index(t => t.VeiculoId);
            
            CreateTable(
                "dbo.Notificacao",
                c => new
                    {
                        NotificacaoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Lida = c.Boolean(nullable: false),
                        Cabecalho = c.String(maxLength: 100, unicode: false),
                        Texto = c.String(maxLength: 5000, unicode: false),
                    })
                .PrimaryKey(t => t.NotificacaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movimento", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.Movimento", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.Pessoa", "UnidadeId", "dbo.Unidade");
            DropForeignKey("dbo.Veiculo", "UnidadeId", "dbo.Unidade");
            DropForeignKey("dbo.PessoaEndereco", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaDocumento", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.PessoaContato", "PessoaId", "dbo.Pessoa");
            DropForeignKey("dbo.MenuAcesso", "MenuId", "dbo.Menu");
            DropIndex("dbo.Movimento", new[] { "VeiculoId" });
            DropIndex("dbo.Movimento", new[] { "PessoaId" });
            DropIndex("dbo.Veiculo", new[] { "UnidadeId" });
            DropIndex("dbo.PessoaEndereco", new[] { "PessoaId" });
            DropIndex("dbo.PessoaDocumento", new[] { "PessoaId" });
            DropIndex("dbo.PessoaContato", new[] { "PessoaId" });
            DropIndex("dbo.Pessoa", new[] { "UnidadeId" });
            DropIndex("dbo.MenuAcesso", new[] { "MenuId" });
            DropTable("dbo.Notificacao");
            DropTable("dbo.Movimento");
            DropTable("dbo.Usuario");
            DropTable("dbo.Veiculo");
            DropTable("dbo.Unidade");
            DropTable("dbo.PessoaEndereco");
            DropTable("dbo.PessoaDocumento");
            DropTable("dbo.PessoaContato");
            DropTable("dbo.Pessoa");
            DropTable("dbo.MenuAcesso");
            DropTable("dbo.Menu");
        }
    }
}
