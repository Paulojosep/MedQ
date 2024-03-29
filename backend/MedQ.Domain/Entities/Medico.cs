﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedQ.Domain.Entities
{
    public class Medico : Entity
    {
        public Medico()
        {
            AgendamentoDisponiveis = new HashSet<AgendamentoDisponiveis>();
        }

        public Medico(int id, string nome, string cPF, int especialidadeId, int estabelecimentoId)
        {
            Id = id;
            Nome = nome;
            CPF = cPF;
            EspecialidadeId = especialidadeId;
            EstabelecimentoId = estabelecimentoId;
        }

        public string Nome { get; set; }
        public string CPF { get; set; }
        public int EspecialidadeId { get; set; }
        public int EstabelecimentoId { get; set; }

        public virtual Especialidade Especialidade { get; set; }
        public virtual Estabelecimento Estabelecimento { get; set; }

        public virtual ICollection<AgendamentoDisponiveis> AgendamentoDisponiveis { get; set; }
    }
}
