using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        public void Create(Personagen NovoPersonagem);

        public List<Personagen> Read();

        public Personagen ReadId(int Id);

        public void Delete(int Id);
    }
}
