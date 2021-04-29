using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeClassRepository
    {
        public void Create(HabilidadeClass NovoHabilidadeClass);

        public List<HabilidadeClass> Read();

        public HabilidadeClass ReadId(int Id);

        public void Delete(int Id);
    }
}
