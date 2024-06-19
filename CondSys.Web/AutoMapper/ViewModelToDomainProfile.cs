using System;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using CondSys.Model.UH;
using CondSys.Model;
using CondSys.Model.Usuarios;
using CondSys.Helpers;
using CondSys.Model.Configuracao;
using CondSys.Model.Visitante;
using CondSys.Model.Correspondencias;

namespace CondSys.Web.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainProfile"; }
        }

        public ViewModelToDomainProfile()
        { }

        public ViewModelToDomainProfile(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UnidadeDto, Unidade>()
            .ForMember(f => f.UnidadeId, s => s.MapFrom(a => a.UnidadeId))
            .ForMember(f => f.Andar, s => s.MapFrom(a => a.Andar))
            .ForMember(f => f.Bloco, s => s.MapFrom(a => a.Bloco))
            .ForMember(f => f.Localizacao, s => s.MapFrom(a => a.Localizacao))
            .ForMember(f => f.Numero, s => s.MapFrom(a => a.Numero));

            cfg.CreateMap<MoradorDto, Pessoa>()
            .ForMember(f => f.PessoaId, s => s.MapFrom(a => a.PessoaId))
            .ForMember(f => f.DataNascimento, s => s.MapFrom(a => Convert.ToDateTime(a.DataNascimento)))
            .ForMember(f => f.Genero, s => s.MapFrom(a => a.Sexo))
            .ForMember(f => f.NomeSocial, s => s.MapFrom(a => a.Nome))
            .ForMember(f => f.Profissao, s => s.MapFrom(a => a.Profissao))
            .ForMember(f => f.ProprietarioMorador, s => s.MapFrom(a => a.Proprietario))
            .ForMember(f => f.TipoPessoaMovimento, s => s.MapFrom(a => a.Tipo))
            .ForMember(f => f.Ativo, s => s.MapFrom(a => a.Ativo))
            .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome));

            cfg.CreateMap<MoradorDto, Morador>()
            .ForMember(f => f.PessoaId, s => s.MapFrom(a => a.PessoaId))
            .ForMember(f => f.DataNascimento, s => s.MapFrom(a => a.DataNascimento))
            .ForMember(f => f.Genero, s => s.MapFrom(a => a.Sexo))
            .ForMember(f => f.NomeSocial, s => s.MapFrom(a => a.Nome))
            .ForMember(f => f.Profissao, s => s.MapFrom(a => a.Profissao))
            .ForMember(f => f.ProprietarioMorador, s => s.MapFrom(a => a.Proprietario))
            .ForMember(f => f.TipoPessoaMovimento, s => s.MapFrom(a => a.Tipo))
            .ForMember(f => f.Ativo, s => s.MapFrom(a => a.Ativo))
            .ForMember(f => f.PermiteAutorizarPortaria, s => s.MapFrom(a => a.PermiteAutorizarPortaria))
            .ForMember(f => f.PermiteAutorizarVisitante, s => s.MapFrom(a => a.PermiteAutorizarVisitante))
            .ForMember(f => f.UnidadeId, s => s.MapFrom(a => a.Unidade.UnidadeId))
            .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome));

            cfg.CreateMap<UsuarioDto, Usuario>()
              .ForMember(f => f.Admin, s => s.MapFrom(a => a.Admin))
              .ForMember(f => f.Email, s => s.MapFrom(a => a.Email))
              .ForMember(f => f.GrupoAcesso, s => s.MapFrom(a => a.GrupoAcesso))
              .ForMember(f => f.Nome, s => s.MapFrom(a => a.Nome))
              .ForMember(f => f.Senha, s => s.MapFrom(a => a.Senha))
              .ForMember(f => f.UsuarioId, s => s.MapFrom(a => a.UsuarioId))
              .ForMember(f => f.PessoaId, s => s.MapFrom(a => a.PessoaId));

            cfg.CreateMap<ConfiguracaoDto, Configuracao>()
                .ForMember(f => f.SenhaEmail, s => s.MapFrom(a => Encriptacao.Encrypt(a.SenhaEmail)))
                .ForMember(f => f.TelefoneContato, s => s.MapFrom(a => a.TelefoneContato.RemoveSpecialChars()))
                .ForMember(f => f.CelularContato, s => s.MapFrom(a => a.CelularContato.RemoveSpecialChars()))
                .ForMember(f => f.Cep, s => s.MapFrom(a => a.Cep.RemoveSpecialChars()));

            cfg.CreateMap<MovimentoDto, Movimento>()
                .ForMember(f => f.DataHoraEntrada, s => s.MapFrom(a => a.DataHoraEntrada))
                .ForMember(f => f.DataHoraSaida, s => s.MapFrom(a => a.DataHoraSaida))
                .ForMember(f => f.NroCartao, s => s.MapFrom(a => a.NroCartao))
                .ForMember(f => f.PlacaVeiculo, s => s.MapFrom(a => a.PlacaVeiculo))
                .ForMember(f => f.Tipo, s => s.MapFrom(a => a.Tipo))
                .ForMember(f => f.VisitanteId, s => s.MapFrom(a => a.PessoaId))
                .ForMember(f => f.MoradorId, s => s.MapFrom(a => a.MoradorId));

            cfg.CreateMap<VisitanteDto, Visitante>();

            cfg.CreateMap<CorrespondenciaDto, Correspondencia>()
                .ForMember(f => f.CorrespondenciaId, s => s.MapFrom(a => a.Id))
                .ForMember(f => f.DataChegada, s => s.MapFrom(a => a.DataChegada))
                .ForMember(f => f.DataEntrega, s => s.MapFrom(a => a.DataEntrega))
                .ForMember(f => f.Folha, s => s.MapFrom(a => a.Folha))
                .ForMember(f => f.Mensagem, s => s.MapFrom(a => a.Mensagem))
                .ForMember(f => f.MoradorId, s => s.MapFrom(a => a.MoradorId))
                .ForMember(f => f.UsuarioRecebimentoId, s => s.MapFrom(a => a.RecebidoPorId))
                .ForMember(f => f.UsuarioEntregaId, s => s.MapFrom(a => a.EntreguePorId))
                .ForMember(f => f.Tipo, s => s.MapFrom(a => a.Tipo));

            cfg.CreateMap<AvisosDto, Aviso>()
                .ForMember(f => f.AvisoId, s => s.MapFrom(a => a.AvisoId))
                .ForMember(f => f.Data, s => s.MapFrom(a => a.Data))
                .ForMember(f => f.Titulo, s => s.MapFrom(a => a.Titulo))
                .ForMember(f => f.Texto, s => s.MapFrom(a => a.Mensagem));

        }
    }
}
