using AutoMapper;
using CondSys.Enumerator;
using CondSys.Helpers;
using CondSys.Model;
using CondSys.Model.Configuracao;
using CondSys.Model.Correspondencias;
using CondSys.Model.Menu;
using CondSys.Model.UH;
using CondSys.Model.Usuarios;
using CondSys.Model.Visitante;
using System;
using System.Linq;

namespace CondSys.Web.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelProfile"; }
        }

        public DomainToViewModelProfile()
        {
        }

        public DomainToViewModelProfile(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Usuario, UsuarioDto>()
            .ForMember(f => f.Admin, s => s.MapFrom(a => a.Admin))
            .ForMember(f => f.Email, s => s.MapFrom(a => a.Email))
            .ForMember(f => f.GrupoAcesso, s => s.MapFrom(a => (int)a.GrupoAcesso))
            .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome))
            .ForMember(f => f.UsuarioId, s => s.MapFrom(a => a.UsuarioId))
            .ForMember(f => f.PessoaId, s => s.MapFrom(a => a.PessoaId));

            cfg.CreateMap<Menu, MenuDto>()
            .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome))
            .ForMember(f => f.Nivel, s => s.MapFrom(a => a.Nivel))
            .ForMember(f => f.Url, s => s.MapFrom(a => a.Url))
            .ForMember(f => f.Icone, s => s.MapFrom(a => a.Icone))
            .ForMember(f => f.MenuId, s => s.MapFrom(a => a.MenuId));

            cfg.CreateMap<Morador, MoradorDto>()
            .ForMember(f => f.PessoaId, s => s.MapFrom(a => a.PessoaId))
            .ForMember(f => f.Ativo, s => s.MapFrom(a => a.Ativo))
            .ForMember(f => f.Status, s => s.MapFrom(a => a.Ativo ? "Ativo" : "Inativo"))
            .ForMember(f => f.DataNascimento, s => s.MapFrom(a => a.DataNascimento == DateTime.MinValue? string.Empty : a.DataNascimento.ToString("dd/MM/yyyy")))
            .ForMember(f => f.Sexo, s => s.MapFrom(a => a.Genero))
            .ForMember(f => f.Profissao, s => s.MapFrom(a => a.Profissao))
            .ForMember(f => f.Proprietario, s => s.MapFrom(a => a.ProprietarioMorador))
            .ForMember(f => f.Tipo, s => s.MapFrom(a => a.TipoPessoaMovimento))
            .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome))
            .ForMember(f => f.PermiteAutorizarPortaria, s => s.MapFrom(a => a.PermiteAutorizarPortaria))
            .ForMember(f => f.PermiteAutorizarVisitante, s => s.MapFrom(a => a.PermiteAutorizarVisitante))
            .ForMember(f => f.Cpf, s => s.MapFrom(a => a.Documentos.FirstOrDefault(f => f.Tipo == Enumerator.TipoDocumento.cpf && f.PessoaId == a.PessoaId).Documento))
            .ForMember(f => f.Passaport, s => s.MapFrom(a => a.Documentos.FirstOrDefault(f => f.Tipo == Enumerator.TipoDocumento.passport && f.PessoaId == a.PessoaId).Documento))
            .ForMember(f => f.Rg, s => s.MapFrom(a => a.Documentos.FirstOrDefault(f => f.Tipo == Enumerator.TipoDocumento.rg && f.PessoaId == a.PessoaId).Documento))
            .ForMember(f => f.DocCpfId, s => s.MapFrom(a => a.Documentos.FirstOrDefault(f => f.Tipo == Enumerator.TipoDocumento.cpf && f.PessoaId == a.PessoaId).PessoaDocumentoId))
            .ForMember(f => f.DocPassaportId, s => s.MapFrom(a => a.Documentos.FirstOrDefault(f => f.Tipo == Enumerator.TipoDocumento.passport && f.PessoaId == a.PessoaId).PessoaDocumentoId))
            .ForMember(f => f.DocRgId, s => s.MapFrom(a => a.Documentos.FirstOrDefault(f => f.Tipo == Enumerator.TipoDocumento.rg && f.PessoaId == a.PessoaId).PessoaDocumentoId))
            .ForMember(f => f.Email, s => s.MapFrom(a => a.Contatos.FirstOrDefault(f => f.Tipo == Enumerator.TipoContato.Email && f.PessoaId == a.PessoaId).Contato))
            .ForMember(f => f.ContatoEmailId, s => s.MapFrom(a => a.Contatos.FirstOrDefault(f => f.Tipo == Enumerator.TipoContato.Email && f.PessoaId == a.PessoaId).PessoaContatoId))
            .ForMember(f => f.ContatoCelularId, s => s.MapFrom(a => a.Contatos.FirstOrDefault(f => f.Tipo == Enumerator.TipoContato.Celular && f.PessoaId == a.PessoaId).PessoaContatoId))
            .ForMember(f => f.Celular, s => s.MapFrom(a => a.Contatos.FirstOrDefault(f => f.Tipo == Enumerator.TipoContato.Celular && f.PessoaId == a.PessoaId).Contato))
            .ForMember(f => f.ContatoFoneId, s => s.MapFrom(a => a.Contatos.FirstOrDefault(f => f.Tipo == Enumerator.TipoContato.Telefone && f.PessoaId == a.PessoaId).PessoaContatoId))
            .ForMember(f => f.Telefone, s => s.MapFrom(a => a.Contatos.FirstOrDefault(f => f.Tipo == Enumerator.TipoContato.Telefone && f.PessoaId == a.PessoaId).Contato)).PreserveReferences();

            cfg.CreateMap<Unidade, UnidadeDto>()
            .ForMember(f => f.UnidadeId, s => s.MapFrom(a => a.UnidadeId))
            .ForMember(f => f.Andar, s => s.MapFrom(a => a.Andar))
            .ForMember(f => f.Bloco, s => s.MapFrom(a => a.Bloco))
            .ForMember(f => f.Localizacao, s => s.MapFrom(a => a.Localizacao))
            .ForMember(f => f.StatusDesc, s => s.MapFrom(a => a.Status.ObtemDescricao()))
            .ForMember(f => f.Status, s => s.MapFrom(a => a.Status))
            .ForMember(f => f.Numero, s => s.MapFrom(a => a.Numero)).PreserveReferences();

            cfg.CreateMap<Configuracao, ConfiguracaoDto>();

            cfg.CreateMap<Morador, MoradorPesquisa>()
                .ForMember(f => f.Unidade, s => s.MapFrom(a => a.Unidade.Numero))
                .ForMember(f => f.PessoaId, s => s.MapFrom(a => a.PessoaId))
                .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome));

            cfg.CreateMap<Movimento, MovimentoDto>()
                .ForMember(f => f.DataHoraEntrada, s => s.MapFrom(a => a.DataHoraEntrada))
                .ForMember(f => f.DataHoraSaida, s => s.MapFrom(a => a.DataHoraSaida))
                .ForMember(f => f.NroCartao, s => s.MapFrom(a => a.NroCartao))
                .ForMember(f => f.PlacaVeiculo, s => s.MapFrom(a => a.PlacaVeiculo))
                .ForMember(f => f.Tipo, s => s.MapFrom(a => a.Tipo))
                .ForMember(f => f.NomeVisitante, s => s.MapFrom(a => a.Visitante.Nome))
                .ForMember(f => f.Doc, s => s.MapFrom(a => a.Visitante.Documentos.FirstOrDefault().Documento))
                .ForMember(f => f.DocId, s => s.MapFrom(a => a.Visitante.Documentos.FirstOrDefault().PessoaDocumentoId))
                .ForMember(f => f.TipoDoc, s => s.MapFrom(a => a.Visitante.Documentos.FirstOrDefault().Tipo))
                .ForMember(f => f.MoradorNome, s => s.MapFrom(a => a.Morador.Nome))
                .ForMember(f => f.MoradorId, s => s.MapFrom(a => a.MoradorId)).PreserveReferences();

            cfg.CreateMap<Visitante, VisitanteDto>()
                .ForMember(f => f.VisitanteId, s => s.MapFrom(a => a.PessoaId))
                .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome))
                .ForMember(f => f.Foto, s => s.MapFrom(a => ImageHelper.ArrayByteToBase64(a.Foto)))
                .ForMember(f => f.Documento, s => s.MapFrom(a => a.Documentos.FirstOrDefault().Documento))
                .ForMember(f => f.Tipo, s => s.MapFrom(a => a.Documentos.FirstOrDefault().Tipo));

            cfg.CreateMap<Correspondencia, CorrespondenciaDto>()
                .ForMember(f => f.Id, s => s.MapFrom(a => a.CorrespondenciaId))
                .ForMember(f => f.Entregue, s => s.MapFrom(a => a.Entregue))
                .ForMember(f => f.DataChegada, s => s.MapFrom(a => a.DataChegada))
                .ForMember(f => f.DataEntrega, s => s.MapFrom(a => a.DataEntrega))
                .ForMember(f => f.Folha, s => s.MapFrom(a => a.Folha))
                .ForMember(f => f.Mensagem, s => s.MapFrom(a => a.Mensagem))
                .ForMember(f => f.MoradorNome, s => s.MapFrom(a => a.Morador.Nome))
                .ForMember(f => f.MoradorId, s => s.MapFrom(a => a.MoradorId))
                .ForMember(f => f.EntreguePorId, s => s.MapFrom(a => a.UsuarioEntregaId))
                .ForMember(f => f.RecebidoPorId, s => s.MapFrom(a => a.UsuarioRecebimentoId))
                .ForMember(f => f.Tipo, s => s.MapFrom(a => a.Tipo)).PreserveReferences();
            cfg.CreateMap<Aviso, AvisosDto>()
                .ForMember(f => f.AvisoId, s => s.MapFrom(a => a.AvisoId))
                .ForMember(f => f.Data, s => s.MapFrom(a => a.Data))
                .ForMember(f => f.Titulo, s => s.MapFrom(a => a.Titulo))
                .ForMember(f => f.Mensagem, s => s.MapFrom(a => a.Texto)).PreserveReferences();
        }
    }
}
