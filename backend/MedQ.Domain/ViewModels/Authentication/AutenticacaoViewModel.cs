using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.ViewModels.Authentication
{
    public class JwtVM
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime Acesso { get; set; }
        public bool EhAdmin { get; set; }
        public MenuVM[] Menu { get; set; }
    }

    public class MenuVM
    {
        public MenuVM()
        {
            this.Visible = true;
        }

        public string Label { get; set; }
        public string RouterLink { get; set; }
        public bool Visible { get; set; }
        public MenuVM[] Items { get; set; }
    }

    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
