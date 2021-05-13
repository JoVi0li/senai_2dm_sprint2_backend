using Senai.SpMedicalGroup.WebApi.Contexts;
using Senai.SpMedicalGroup.WebApi.Domains;
using Senai.SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        SP_Medical_GroupContext ctx = new SP_Medical_GroupContext();


        public void Create(TipoUsuario NovoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(NovoTipoUsuario);

            ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            ctx.TipoUsuarios.Remove(ReadById(Id));

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Read()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario ReadById(int Id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(t => t.IdTipoUsuario == Id);
        }

        public void Update(int Id, TipoUsuario TipoUsuarioAtualizado)
        {
            TipoUsuario TipoUsuarioBuscado = ReadById(Id);

            if (TipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                TipoUsuarioBuscado.NomeTipoUsuario = TipoUsuarioAtualizado.NomeTipoUsuario;

                ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

                ctx.SaveChanges();
            }
        }
    }
}
