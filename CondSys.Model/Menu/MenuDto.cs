﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondSys.Model.Menu
{
    public class MenuDto
    {
        public string Nome { get; set; }
        public int MenuId { get; set; }
        public int MenuPaiId { get; set; }
        public string Nivel { get; set; }
        public string Url { get; set; }
        public string Icone { get; set; }
    }
}
