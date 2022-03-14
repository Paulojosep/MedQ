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
        Task<MensagensDTO> SetViwedTrue(int id);
        string GetDay();
        string SetDay(string day);
        string GetTime();
    }
}
