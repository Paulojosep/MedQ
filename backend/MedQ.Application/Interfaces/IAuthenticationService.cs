using MedQ.Domain.ViewModels.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Usuario RecuperarUsuario();
        void DefinirUsuario(ClaimsPrincipal principal);
        Task<JwtVM> ObterDadosUsuario();
    }
}
