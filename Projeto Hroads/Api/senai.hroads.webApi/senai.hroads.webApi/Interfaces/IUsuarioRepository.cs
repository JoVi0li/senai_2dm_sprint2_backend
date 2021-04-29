using senai.hroads.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IUsuarioRepository
    {
        public void Create(Usuario NovoUsuario);

        public List<Usuario> Read();

        public Usuario ReadId(int Id);

        public void Delete(int Id);
    }
}
