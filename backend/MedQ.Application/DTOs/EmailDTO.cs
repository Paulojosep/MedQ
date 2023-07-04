using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.DTOs
{
    public class EmailDTO
    {
        public EmailDTO()
        {
        }

        public EmailDTO(string ownerRef, string emailFrom, string emailTo, string subject, string text)
        {
            this.ownerRef = ownerRef;
            this.emailFrom = emailFrom;
            this.emailTo = emailTo;
            this.subject = subject;
            this.text = text;
        }

        public string ownerRef;
        public string emailFrom;
        public string emailTo;
        public string subject;
        public string text;
    }
}
