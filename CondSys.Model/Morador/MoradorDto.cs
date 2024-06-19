using CondSys.Attributes;
using CondSys.Enumerator;
using CondSys.Model.UH;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model
{
    public class MoradorDto
    {
        public MoradorDto()
        {
            Unidade = new UnidadeDto();
        }
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(100, ErrorMessage = "O limite máximo é de 100 caracteres")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "Proprietário")]
        public bool Proprietario { get; set; }

        [StringLength(14)]
        [Required(ErrorMessage = "Informe o Cpf")]
        [Display(Name = "Nro Cpf")]
        [CPF]
        public string Cpf { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Informe o RG")]
        [Display(Name = "Nro RG")]
        public string Rg { get; set; }

        [StringLength(20, ErrorMessage = "Informe o máximo de 20 números")]
        [Display(Name = "Nro Passaport")]
        public string Passaport { get; set; }

        public Genero Sexo { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataNascimento]
        [Required(ErrorMessage ="Informe a data de nascimento")]
        public String DataNascimento { get; set; }

        [Display(Name = "Permitir Autorizar Entrada na Portaria")]
        public bool PermiteAutorizarPortaria { get; set; }

        [Display(Name = "Permitir Gerenciar Visitantes")]
        public bool PermiteAutorizarVisitante { get; set; }
        public UnidadeDto Unidade { get; set; }
        public TipoPessoaMovimento Tipo { get; set; }
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Informe um Email")]
        [EmailAddress]
        public string Email { get; set; }

        public int DocCpfId { get; set; }
        public int DocRgId { get; set; }
        public int DocPassaportId { get; set; }

        public int ContatoEmailId { get; set; }
        public int ContatoFoneId { get; set; }
        public int ContatoCelularId { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Celular")]
        public string Celular { get; set; }
    }

    public class MoradorPesquisa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Unidade { get; set; }
    }
}
