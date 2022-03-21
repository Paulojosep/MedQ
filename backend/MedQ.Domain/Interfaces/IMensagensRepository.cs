using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IMensagensRepository
    {
        Task<Mensagens> GetByIdAsync(int id);
        Task<Mensagens> GetViewdMensagensAsync(int socioId);
        Task<Mensagens> GetMensagensAsync(int socioId);
        Task<Mensagens> CreateAsync(Mensagens mensagens);
        Task<Mensagens> SetViwedTrueAsync(Mensagens mensagens);
        Task CreateConsultationMessage(string titulo, string resumo, string texto, string data, string hora, int socio_id);
    }
}
