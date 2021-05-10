using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IConsultumRepository
    {

        void Create(Consultum NovoConsultum);

        List<Consultum> Read();

        Consultum ReadById(int Id);

        void Update(Consultum ConsultumAtualizado, int Id);

        void Delete(int Id);
    }
}
