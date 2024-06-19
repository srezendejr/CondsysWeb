using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Usuarios
{
    public class AlterarSenhaDto
    {
        public int UsuarioId { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Nova Senha")]
        public string NovaSenha { get; set; }
        [Display(Name ="Confirma Nova Senha")]
        [DataType(DataType.Password)]
        [Compare("NovaSenha", ErrorMessage ="As senhas informadas estão diferentes")]
        public string ConfirmaNovaSenha { get; set; }
    }
}
