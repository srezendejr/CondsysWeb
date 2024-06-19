﻿using CondSys.Enumerator;
using CondSys.Model.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Data.Services
{
    public interface IMenuService
    {
        Task<List<Menu>> GetMenuGrupoAcesso(GruposAcesso grupoAcesso);
    }
}
