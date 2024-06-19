using CondSys.Model;
using CondSys.Web.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Services
{
    public interface UsuarioServices
    {
        Usuario ValidaLogin(Login model);
    }
}
