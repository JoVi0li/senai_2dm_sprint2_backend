﻿using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class Personagen
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public string CapacidadeMaximaVida { get; set; }
        public string CapacidadeMaximaMana { get; set; }
        public string DataAtualizacao { get; set; }
        public string DataCriacao { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
