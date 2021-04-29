using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClassRepository
    {
        public void Create(Class NovaClass);

        public List<Class> Read();

        public Class ReadId(int Id);

        public void Delete(int Id);
    }
}
