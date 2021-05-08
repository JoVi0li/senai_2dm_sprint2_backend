using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IClassRepository
    {

        public void Create(Class NovoClass);

        public List<Class> Read();

        public Class ReadById(int Id);

        public void Update(Class ClassAtualizado, int Id);

        public void Delete(int Id);
    }
}
