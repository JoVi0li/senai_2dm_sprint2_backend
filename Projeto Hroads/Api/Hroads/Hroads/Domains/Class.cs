using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads.Domains
{
    public partial class Class
    {
        public Class()
        {
            HabilidadeClasses = new HashSet<HabilidadeClass>();
            Personagens = new HashSet<Personagen>();
        }

        public int IdClasse { get; set; }
        public string NomeClasse { get; set; }

        public virtual ICollection<HabilidadeClass> HabilidadeClasses { get; set; }
        public virtual ICollection<Personagen> Personagens { get; set; }
    }
}
