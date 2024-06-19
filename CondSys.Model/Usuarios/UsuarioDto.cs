using CondSys.Enumerator;
using CondSys.Model.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondSys.Model.Usuarios
{
    public class UsuarioDto
    {
        public UsuarioDto()
        {
            Menus = new List<MenuDto>();
        }

        public int UsuarioId { get; set; }
        [Display(Name ="Nome")]
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Display(Name = "Administrador")]
        public bool Admin { get; set; }

        [Display(Name = "Grupo de Acesso")]
        public GruposAcesso GrupoAcesso { get; set; }
        public ICollection<MenuDto> Menus { get; set; }

        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        [Display(Name ="Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirma Senha")]
        [Compare("Senha", ErrorMessage = "A confirmação de senha está inválida.")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        [Display(Name = "Status")]
        [NotMapped]
        public string Status => Ativo ? "Ativo" : "Inativo";

        [Display(Name = "Grupo de Acesso")]
        [NotMapped]
        public string Acesso => GrupoAcesso.ObtemDescricao();

        [Display(Name = "Administrador")]
        [NotMapped]
        public string Administrador => Admin ? "Sim" : "Não";

        public int? PessoaId { get; set; }
    }
}
