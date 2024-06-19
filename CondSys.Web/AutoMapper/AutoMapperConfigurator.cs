using AutoMapper;
using CondSys.Model;
using CondSys.Model.Menu;
using CondSys.Model.UH;
using CondSys.Model.Usuarios;
using System.Linq;

namespace CondSys.Web.AutoMapper
{
    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                new DomainToViewModelProfile(cfg);
                new ViewModelToDomainProfile(cfg);
            });
        }
    }
}