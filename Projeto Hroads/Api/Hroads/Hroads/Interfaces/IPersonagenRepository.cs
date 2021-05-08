using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IPersonagenRepository
    {

        public void Create(Personagen NovoPersonagen);

        public List<Personagen> Read();

        public Personagen ReadById(int Id);

        public void Update(Personagen PersonagenAtualizado, int Id);

        public void Delete(int Id);
    }
}
