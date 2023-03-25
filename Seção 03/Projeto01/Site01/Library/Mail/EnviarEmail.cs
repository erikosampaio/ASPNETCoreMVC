using Site01.Models;
using System;
using System.Net;
using System.Net.Mail;

namespace Site01.Library.Mail
{
    public class EnviarEmail
    {
        public static void EnviarMensagemContato(Contato contato)
        {
            string conteudo = string.Format("Nome: {0}<br /> Email: {1}<br /> Assunto: {2}<br /> Mensagem: {3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);
            // Configurar o servidor SMTP
            SmtpClient smtp = new SmtpClient(Constants.ServidorSMTP, Constants.PortaSMTP);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(Constants.Usuario, Constants.Senha);

            // Mensagem de email
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(Constants.Usuario);
            mensagem.To.Add(Constants.Usuario);
            mensagem.Subject = "Teste de envio de email com .NET";

            mensagem.IsBodyHtml = true;
            mensagem.Body = "<h1>Formulário de contato</h1> " + conteudo;

            try
            {
                smtp.Send(mensagem);
            }
            catch (Exception e)
            {
                throw new Exception("Erro na tentaviva de envio do email! --> " + e.Message);
            }
        }
    }
}
