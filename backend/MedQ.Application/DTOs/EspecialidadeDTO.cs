using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.DTOs
{
    public class EspecialidadeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<FilaDTO> Filas { get; private set; }
        public ICollection<MedicoDTO> Medicos { get; private set; }
    }
}
