﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads.Domains
{
    public partial class HabilidadeClass
    {
        public int IdHabilidadeClasses { get; set; }
        public int? IdClasse { get; set; }
        public int? IdHabilidade { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}