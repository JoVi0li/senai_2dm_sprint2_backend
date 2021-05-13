using Senai.SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        void Create(Especialidade NovaEspecialidade);

        List<Especialidade> Read();

        Especialidade ReadById(int Id);

        void Update(int Id, Especialidade EspecialidadeAtualizada);

        void Delete(int Id);
    }
}
