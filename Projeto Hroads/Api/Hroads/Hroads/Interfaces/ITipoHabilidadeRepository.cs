using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        public void Create(TipoHabilidade NovoTipoHabilidade);

        public List<TipoHabilidade> Read();

        public TipoHabilidade ReadById(int Id);

        public void Update(TipoHabilidade TipoHabilidadeAtualizado, int Id);

        public void Delete(int Id);
    }
}
