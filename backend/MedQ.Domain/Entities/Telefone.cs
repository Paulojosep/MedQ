﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Telefone : Entity
    {
        public string DDD { get; set; }
        public string Numero { get; set; }
        [Column("fk_estabelecimento_id")]
        public int EstabelecimentoId { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
        [Column("tb_socio_id")]
        public int SocioId { get; set; }
        public Socio Socio { get; set; }
    }
}
