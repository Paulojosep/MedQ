using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MedQ.Application.Validations
{
    public class EmailValidator
    {
        public bool ValidacaoEmail(string email)
        {
            Regex expression = new Regex(@"\w+[a-zA-Z_]+?\.[a-zA-Z_]{2,3}");
            if (expression.IsMatch(email))
                return true;
            return false;
        }
    }
}
