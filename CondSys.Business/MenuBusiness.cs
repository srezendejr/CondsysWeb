using CondSys.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Enumerator;
using CondSys.Model.Menu;
using CondSys.Data.Context;
using System.Data.Entity;

namespace CondSys.Business
{
    public class MenuBusiness : IMenuService
    {
        ContextMySql _context;
        public MenuBusiness(ContextMySql context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetMenuGrupoAcesso(GruposAcesso grupoAcesso)
        {
            return await _context.Menus.Include(i => i.MenusAcesso).SelectMany(s => s.MenusAcesso).Where(s => s.GrupoAcesso == grupoAcesso).Select(se => se.Menu).OrderBy(b => b.Nome).ToListAsync();
        }
    }
}
