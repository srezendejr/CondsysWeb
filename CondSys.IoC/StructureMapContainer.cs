using CondSys.Business;
using CondSys.Data.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.IoC
{
    public class StructureMapContainer
    {
        public static readonly IContainer Container;
        static StructureMapContainer()
        {
            Container = Initializer();
        }

        public static IContainer Initializer()
        {
            var container = new Container(registry =>
            {
                registry.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });
                //Services
                registry.For<IUsuarioService>().Use<UsuarioBusiness>();
                registry.For<IMenuService>().Use<MenuBusiness>();
                registry.For<IPessoaService>().Use<PessoaBusiness>();
                registry.For<IUnidadeService>().Use<UnidadeBusiness>();
                registry.For<IConfiguracaoService>().Use<ConfiguracaoBusiness>();
                registry.For<IMovimentoService>().Use<MovimentoBusiness>();
                registry.For<ICorrespondenciaService>().Use<CorrespondenciaBusiness>();
                registry.For<IAvisoService>().Use<AvisoBusiness>();
                //registry.For<ISubCategoriaServices>().Use<SubCategoriaServices>();

                //Repository
                //registry.For<IRepositoryBase<Categoria>>().Use<RepositoryBase<Categoria>>();
                //registry.For<IRepositoryBase<SubCategoria>>().Use<RepositoryBase<SubCategoria>>();
                //registry.For<IFinanceiroData>().Use<FinanceiroData>();
                //registry.For<IPlanoData>().Use<PlanoData>();
                //registry.For<IConfiguracaoData>().Use<ConfiguracaoData>();
            });
            return container;
        }

        public static T Get<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
