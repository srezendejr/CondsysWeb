using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CondSys.Data.Services;
using CondSys.Data.Context;
using System.Data.Entity;
using System.Web;
using System.Net.Mail;
using System.Net;
using CondSys.Helpers;
using System.Net.Mime;
using System.IO;

namespace CondSys.Sender
{
    public static class Email
    {

        public static void EnviarEmail(string destinatario, string assunto, string mensagem)
        {
            EnviarEmail(destinatario, assunto, mensagem, string.Empty);
        }

        public static void EnviarEmail(string nomeUsuario, string emailUsuario, string assunto, string novaSenha, bool enviaAutomatico = true)
        {
            var template = string.Format(PegaTemplateEmail("EmailTemplate.html"), nomeUsuario, novaSenha);
            EnviarEmail(emailUsuario, assunto, template, string.Empty);
        }

        private static void EnviarEmail(string destinatario, string assunto, string mensagem, string anexo)
        {
            ContextMySql _context = new ContextMySql();
            var Config = _context.Configuracoes.FirstOrDefault();
            if (Config != null)
            {
                var mail = new MailMessage("sergio.rezende.jr@gmail.com", destinatario, assunto, mensagem);
                mail.ReplyToList.Add(Config.Email);
                if (!string.IsNullOrEmpty(anexo) && anexo.Contains("data:image/png;base64,"))
                {
                    AlternateView view = AlternateView.CreateAlternateViewFromString(mensagem, null, MediaTypeNames.Text.Html);

                    LinkedResource resource = new LinkedResource(new MemoryStream(Convert.FromBase64String(anexo.Replace("data:image/png;base64,", ""))), "image/png");
                    resource.ContentId = "Imagem1";
                    resource.TransferEncoding = TransferEncoding.Base64;
                    view.LinkedResources.Add(resource);

                    mail.AlternateViews.Add(view);
                }
                mail.IsBodyHtml = true;
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("condsysweb@gmail.com", "Junior8020");
                smtpClient.Send(mail);
            }
        }

        public static void EnviarEmailVisitante(DateTime horaEntrada, DateTime? horaSaida, string image, string emailMorador, string nomeVisitante, string assunto)
        {
            string strHoraEntrada = string.Format("Data/Hora Entrada: {0}", horaEntrada.ToString("dd/MM/yyyy HH:mm"));
            string strHoraSaida = !horaSaida.HasValue ? string.Empty : string.Format("Data/Hora Saída: {0}", horaSaida.Value.ToString("dd/MM/yyyy HH:mm"));
            var template = string.Format(PegaTemplateEmail("EmailTemplateVisitante.html"), strHoraEntrada, strHoraSaida, null, nomeVisitante);
            EnviarEmail(emailMorador, assunto, template, image);
        }

        private static string PegaTemplateEmail(string nomeArquivo)
        {
            string caminhoFisico = HttpContext.Current.Server.MapPath("~/");
            string caminho = System.IO.Path.Combine(caminhoFisico, $"Template\\{ nomeArquivo}");
            var template = System.IO.File.ReadAllText(caminho);
            return template;
        }
    }
}
