using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        public void Create(TipoUsuario NovoTipoUsuario);

        public List<TipoUsuario> Read();

        public TipoUsuario ReadId(int Id);

        public void Delete(int Id);
    }
}
