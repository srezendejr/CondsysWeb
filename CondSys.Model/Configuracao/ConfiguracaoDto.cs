using CondSys.Attributes;
using CondSys.Enumerator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Configuracao
{
    public class ConfiguracaoDto
    {
        public int ConfiguracaoId { get; set; }

        [StringLength(100)]
        [Display(Name = "Razão Social")]
        [Required]
        public string RazaoSocial { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome Fantasia")]
        [Required]
        public string NomeFantasia { get; set; }

        [StringLength(15)]
        [Display(Name = "Telefone")]
        public string TelefoneContato { get; set; }

        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Logradouro { get; set; }

        [StringLength(9)]
        [Display(Name = "Cep")]
        public string Cep { get; set; }

        [StringLength(50)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [StringLength(50)]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [StringLength(100)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        public EnumEstados Estado { get; set; }

        [StringLength(100)]
        [Display(Name = "Email de Contato")]
        public string Email { get; set; }

        [StringLength(100)]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string SenhaEmail { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome do Síndico")]
        [Required]
        public string NomeSindico { get; set; }

        [StringLength(100)]
        [Display(Name = "Nome do Zelador")]
        [Required]
        public string NomeZelador { get; set; }

        [StringLength(18)]
        [Display(Name ="CNPJ")]
        [CPF]
        public string Cnpj { get; set; }

        
        public string IPEntradaVisitante { get; set; }
        public int PortaEntradaVisitante { get; set; }
        
        public string IPSaidaVisitante { get; set; }
        public int PortaSaidaVisitante { get; set; }

        public string IPEntradaMorador { get; set; }
        public int PortaEntradaMorador { get; set; }

        public string IPSaidaMorador { get; set; }
        public int PortaSaidaMorador { get; set; }

        public string IPEntradaPedestre { get; set; }
        public int PortaEntradaPedestre { get; set; }

        public string IPSaidaPedestre { get; set; }
        public int PortaSaidaPedestre { get; set; }

        [Display(Name ="Id Twillio Whatsapp")]
        [StringLength(50, ErrorMessage ="O valor digitado é maior que o permitido")]
        public string AccountSidWhatsApp { get; set; }
        [Display(Name = "Token Twillio Whatsapp")]
        [StringLength(50, ErrorMessage = "O valor digitado é maior que o permitido")]
        public string TokenWhatsapp { get; set; }
        [StringLength(15)]
        [Display(Name ="Celular")]
        public string CelularContato { get; set; }
    }
}
