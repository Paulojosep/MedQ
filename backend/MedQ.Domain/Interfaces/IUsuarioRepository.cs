using MedQ.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Socio> Logar(string usuario, string senha);
    }
}
