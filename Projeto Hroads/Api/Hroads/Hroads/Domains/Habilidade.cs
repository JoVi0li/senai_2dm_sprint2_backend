using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            HabilidadeClasses = new HashSet<HabilidadeClass>();
        }

        public int IdHabilidade { get; set; }
        public int? IdTipoHabilidade { get; set; }
        public string NomeHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
        public virtual ICollection<HabilidadeClass> HabilidadeClasses { get; set; }
    }
}
