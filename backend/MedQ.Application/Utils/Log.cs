using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedQ.Application.Utils
{
    public static class Log
    {
        private static string ObterInnerExceptions(Exception exception)
        {
            string mensagem = exception.Message;

            if(exception.InnerException != null)
            {
                mensagem += " Inner Exception " + ObterInnerExceptions(exception.InnerException);
            }

            return mensagem;
        }

        public static void GravarExcessao(Exception exception)
        {
            try
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
                var config = builder.Build();
                var path = config["Logs"]?.ToString();
                var nome = "log_erros_" + DateTime.Now.ToString("dd_MM_yyyy") + ".log";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using StreamWriter valor = new StreamWriter(path + nome, true);

                string mensagem = ObterInnerExceptions(exception);

                mensagem += " STACK TRACE " + exception.StackTrace;

                valor.WriteLine("------------------------------------------------INICIO ERRO------------------------------------------------");
                valor.WriteLine(" ");
                valor.WriteLine(DateTime.Now + " " + mensagem);
                valor.WriteLine(" ");
                valor.WriteLine("------------------------------------------------FIM ERROR------------------------------------------------");
                valor.WriteLine(" ");
                valor.Flush();
            }
            catch
            {}
        }
    }
}
