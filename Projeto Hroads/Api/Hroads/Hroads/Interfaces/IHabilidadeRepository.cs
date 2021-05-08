using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IHabilidadeRepository
    {
        public void Create(Habilidade NovoHabilidade);

        public List<Habilidade> Read();

        public Habilidade ReadById(int Id);

        public void Update(Habilidade HabilidadeAtualizado, int Id);

        public void Delete(int Id);
    }
}
