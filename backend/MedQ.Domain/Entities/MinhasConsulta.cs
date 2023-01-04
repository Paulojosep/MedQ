using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class MinhasConsulta : Entity
    {
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Texto { get; set; }
        public string Pedido { get; set; }
        public string Senha { get; set; }
        public string Profissional { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public string Status { get; set; }
        public string Finished { get; set; }
        public int ConsultaId { get; set; }
        public int SocioId { get; set; }

        public virtual Consultas Consulta { get; set; }
        public virtual Socio Socio { get; set; }

        
    }
}
