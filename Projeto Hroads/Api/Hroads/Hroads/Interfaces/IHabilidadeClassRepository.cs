using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IHabilidadeClassRepository
    {
        public void Create(HabilidadeClass NovoHabilidadeClass);

        public List<HabilidadeClass> Read();

        public HabilidadeClass ReadById(int Id);

        public void Update(HabilidadeClass HabilidadeClassAtualizado, int Id);

        public void Delete(int Id);
    }
}
