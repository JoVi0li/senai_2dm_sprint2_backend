using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IUsuarioRepository
    {

        public void Create(Usuario NovoUsuario);

        public List<Usuario> Read();

        public Usuario ReadById(int Id);

        public void Update(Usuario UsuarioAtualizado, int Id);

        public void Delete(int Id);
    }
}
