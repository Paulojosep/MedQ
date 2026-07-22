using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class MinhasConsulta : Entity
    {
        public MinhasConsulta() {}

        public MinhasConsulta(int id, string titulo, string resumo, string texto, string pedido, string senha, string profissional, DateTime data, DateTime hora, string status, string finished, int consultaId, int socioId)
        {
            Id = id;
            Titulo = titulo;
            Resumo = resumo;
            Texto = texto;
            Pedido = pedido;
            Senha = senha;
            Profissional = profissional;
            Data = data;
            Hora = hora;
            Status = status;
            Finished = finished;
            ConsultaId = consultaId;
            SocioId = socioId;
        }

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
