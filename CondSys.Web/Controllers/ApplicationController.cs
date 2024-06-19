using CondSys.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CondSys.Web.Controllers
{
    public class ApplicationController<TApplication> : Controller
    {
        protected readonly TApplication Application;
        public ApplicationController()
        {
            Application = StructureMapContainer.Get<TApplication>();
        }

    }
}
