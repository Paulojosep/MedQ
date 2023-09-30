using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MedQ.Application.Utils
{
    public class Validacoes
    {
        public static bool Email(string email)
        {
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool Cpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if(cpf.Length != 11 )
            {
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for(int i=0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for(int i=0; i<10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if(resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// deve conter ao menos um dígito númerico
        /// deve conter ao menos uma letra minúscula
        /// deve conter ao menos uma letra maiúscula
        /// deve conter ao menos um caractere especial
        /// deve conter ao menos 8 caracteres
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static bool Senha(string senha)
        {
            return Regex.IsMatch(senha, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])(?:([0-9a-zA-Z$*&@#])(?!\1)){8}$");
        }
    }
}
