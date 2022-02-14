using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface ISocio
    {
        Task<Socio> GetSocioAsync();
        Task<Socio> GetByIdAsync(int id);
        Task<Socio> GetByCPFAsync(string cpf);
        Task<Socio> CreateAsync(Socio socio);
        Task<Socio> UpdateAsycn(int id, Socio socio);
        Task DaleteAsync(int id);
    }
}
