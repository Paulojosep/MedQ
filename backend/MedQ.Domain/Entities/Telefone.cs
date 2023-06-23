using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Telefone : Entity
    {
        public Telefone()
        {
            
        }

        public Telefone(int id, string dDD, string numero, int estabelecimentoId, int socioId)
        {
            Id = id;
            DDD = dDD;
            Numero = numero;
            EstabelecimentoId = estabelecimentoId;
            SocioId = socioId;
        }

        public string DDD { get; set; }
        public string Numero { get; set; }
        public int EstabelecimentoId { get; set; }
        public int SocioId { get; set; }

        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual Socio Socio { get; set; }
    }
}
