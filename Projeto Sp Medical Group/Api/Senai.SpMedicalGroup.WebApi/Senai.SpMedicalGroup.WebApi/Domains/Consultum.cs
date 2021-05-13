using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.SpMedicalGroup.WebApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }
        public int? IdProntuario { get; set; }
        public int? IdMedico { get; set; }
        public string DataConsulta { get; set; }
        public string Situacao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Prontuario IdProntuarioNavigation { get; set; }
    }
}
