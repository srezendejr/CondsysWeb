using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CondSys.Enumerator;
using CondSys.Model.UH;
using CondSys.Helpers;

namespace CondSys.Model
{
    public class Pessoa
    {
        [Key]
        public int PessoaId { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public Genero Genero { get; set; }
        [StringLength(40)]
        public string Profissao { get; set; }
        public bool Ativo { get; set; }
        public bool ProprietarioMorador { get; set; }
        public TipoPessoaFJ Tipo { get; set; }
        public TipoPessoaMovimento TipoPessoaMovimento { get; set; }
        public virtual ICollection<PessoaEndereco> Enderecos { get; set; }
        public virtual ICollection<PessoaDocumento> Documentos { get; set; }
        public virtual ICollection<PessoaContato> Contatos { get; set; }


        public List<PessoaDocumento> AdicionaDocumentos(MoradorDto dto, Pessoa pessoa)
        {
            List<PessoaDocumento> documentos = new List<PessoaDocumento>();
            if (!string.IsNullOrEmpty(dto.Cpf))
            {
                documentos.Add(new PessoaDocumento
                {
                    Documento = dto.Cpf.RemoveSpecialChars(),
                    PessoaId = dto.PessoaId,
                    Tipo = TipoDocumento.cpf,
                    PessoaDocumentoId = dto.DocCpfId,
                    Pessoa = pessoa
                });
            }
            if (!string.IsNullOrEmpty(dto.Rg))
            {
                documentos.Add(new PessoaDocumento
                {
                    Documento = dto.Rg.RemoveSpecialChars(),
                    PessoaId = dto.PessoaId,
                    Tipo = TipoDocumento.rg,
                    PessoaDocumentoId = dto.DocRgId,
                    Pessoa = pessoa
                });

            }
            if (!string.IsNullOrEmpty(dto.Passaport))
            {
                documentos.Add(new PessoaDocumento
                {
                    Documento = dto.Passaport.RemoveSpecialChars(),
                    PessoaId = dto.PessoaId,
                    Tipo = TipoDocumento.passport,
                    PessoaDocumentoId = dto.DocPassaportId,
                    Pessoa = pessoa
                });
            }
            return documentos;
        }

        public List<PessoaContato> AdicionarContato(MoradorDto dto, Pessoa pessoa)
        {
            List<PessoaContato> contatos = new List<PessoaContato>();
            if (!string.IsNullOrEmpty(dto.Email))
            {
                contatos.Add(new PessoaContato
                {
                    Contato = dto.Email,
                    PessoaId = dto.PessoaId,
                    Tipo = TipoContato.Email,
                    PessoaContatoId = dto.ContatoEmailId,
                    Pessoa = pessoa
                });
            }
            if (!string.IsNullOrEmpty(dto.Telefone))
            {
                contatos.Add(new PessoaContato
                {
                    Contato = dto.Telefone.RemoveSpecialChars(),
                    PessoaId = dto.PessoaId,
                    Tipo = TipoContato.Telefone,
                    PessoaContatoId = dto.ContatoFoneId,
                    Pessoa = pessoa
                });
            }
            if (!string.IsNullOrEmpty(dto.Celular))
            {
                contatos.Add(new PessoaContato
                {
                    Contato = dto.Celular.RemoveSpecialChars(),
                    PessoaId = dto.PessoaId,
                    Tipo = TipoContato.Celular,
                    PessoaContatoId = dto.ContatoCelularId,
                    Pessoa = pessoa
                });
            }

            return contatos;
        }

    }
}
