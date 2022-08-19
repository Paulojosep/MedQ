using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Domain.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedUser();
        void SeedRoles();
    }
}
