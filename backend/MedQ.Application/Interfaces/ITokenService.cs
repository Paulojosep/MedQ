using MedQ.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface ITokenService
    {
        string Gerar(SocioDTO usuario);
    }
}
