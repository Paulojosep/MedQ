using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IMensagensService
    {
        Task<MensagensDTO> GetViewdMensagens(int socioId);
        Task<MensagensDTO> GetMensagens(int socioId);
        Task<bool> SetViwedTrue(int id);
        Task<bool> CreateConsultationMessage(ConsultasDTO infoConsultation);
        Task<bool> CreateStatusConsultationMessage(ConsultasDTO infoConsultation, string status);
        string GetDay();
        string SetDay(DateTime day);
        string GetTime();
    }
}
