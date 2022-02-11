﻿using System.Collections.Generic;

namespace MedQ.Domain.Entities
{
    public class Especialidade : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Fila> Filas { get; private set; }
        public ICollection<Medico> Medicos { get; private set; }
    }
}
