using Hroads.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Interfaces
{
    interface ITipoUsuarioRepository
    {

        public void Create(TipoUsuario NovoTipoUsuario);

        public List<TipoUsuario> Read();

        public TipoUsuario ReadById(int Id);

        public void Update(TipoUsuario TipoUsuarioAtualizado, int Id);

        public void Delete(int Id);
    }
}
