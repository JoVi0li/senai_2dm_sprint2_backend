using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        public void Create(Habilidade NovaHabilidade);

        public List<Habilidade> Read();

        public Habilidade ReadId(int Id);

        public void Delete(int Id);
    }
}
