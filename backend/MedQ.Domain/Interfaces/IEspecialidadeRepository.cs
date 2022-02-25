﻿using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetEspecialidadeAsync();
        Task<Especialidade> GetByIdAsync(int id);
        Task<IEnumerable<Especialidade>> GetByEstabelecimentoAsync(int idEstabelecimento);
    }
}