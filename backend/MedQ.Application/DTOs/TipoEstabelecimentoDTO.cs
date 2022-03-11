using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Application.DTOs
{
    public class TipoEstabelecimentoDTO
    {
        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<EstabelecimentoDTO> Estabelecimentos { get; private set; }
    }
}
