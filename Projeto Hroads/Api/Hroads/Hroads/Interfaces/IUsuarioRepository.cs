using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface IUsuarioRepository
    {

        void Create(Usuario NovoUsuario);

        List<Usuario> Read();

        Usuario ReadById(int Id);

        void Update(Usuario UsuarioAtualizado, int Id);

        void Delete(int Id);
    }
}
