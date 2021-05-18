using Senai.SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.WebApi.Interfaces
{
    interface IConsultumRepository
    {
        void Create(Consultum NovaConsultum);

        List<Consultum> Read();

        Consultum ReadById(int Id);

        List<Consultum> ReadByIdDoctor(int Id);

        List<Consultum> ReadByIdPatient(int Id);

        void Update(int Id, Consultum ConsultumAtualizado);

        void Delete(int Id);

    }
}
