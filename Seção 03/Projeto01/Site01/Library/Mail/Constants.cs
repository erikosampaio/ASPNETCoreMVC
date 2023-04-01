using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Mail
{
    public class Constants
    {
        /*
         POP3, IMAP - Ler mensagens de email
         SMTP - Enviar email
         */

        // Autenticação - Gmail
        public readonly static string Usuario = "erikoa.93@gmail.com";
        public readonly static string Senha = "prdtujyupzrcktgk";

        // Servidor SMTP
        public readonly static string ServidorSMTP = "smtp.gmail.com";
        public readonly static int PortaSMTP = 587;
    }
}
