using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.DTOs
{
    public class TipoAtendimentoDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<FilaDTO> Filas { get; set; }
    }
}
