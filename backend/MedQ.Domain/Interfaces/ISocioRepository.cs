﻿using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface ISocioRepository
    {
        Task<IEnumerable<Socio>> GetSocioAsync();
        Task<Socio> GetByIdAsync(int id);
        Task<Socio> GetByCPFAsync(string cpf);
        Task<Socio> CreateAsync(Socio socio);
        Task<Socio> UpdateAsycn(Socio socio);
        Task DaleteAsync(Socio socio);
    }
}