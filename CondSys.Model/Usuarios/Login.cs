using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Usuarios
{
    public class Login
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe um e-mail válido")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "A senha não pode ser vazia")]
        [PasswordPropertyText(true)]
        public string Senha { get; set; }
        
        public bool? Lembrar { get; set; }

    }
}
