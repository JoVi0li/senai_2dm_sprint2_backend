using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        public void Create(TipoHabilidade NovoTipoHabilidade);

        public List<TipoHabilidade> Read();

        public TipoHabilidade ReadId(int Id);

        public void Delete(int Id);
    }
}
