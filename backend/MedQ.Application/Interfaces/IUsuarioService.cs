using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<SocioDTO> Logar(string usuario, string senha);
    }
}
