using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Domain.ViewModels.Authentication
{
    public class DadoUsuario
    {
        public Usuario Usuario { get; set;}
        public List<Menu> Menus { get; set;}
    }
}
