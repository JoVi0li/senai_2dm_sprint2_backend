using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        void Create(Especialidade NovaEspecialidade);

        List<Especialidade> Read();

        Especialidade ReadById(int Id);

        void Update(Especialidade EspecialidadeAtualizada, int Id);

        void Delete(int Id);
    }
}
