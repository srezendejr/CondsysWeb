using CondSys.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CondSys.Sender
{
    public static class TwillioIntegracao
    {
        public static void MensagemWhatsapp(string nomeVisitante, string celularMorador)
        {
            ContextMySql _context = new ContextMySql();
            var Config = _context.Configuracoes.FirstOrDefault();
            if (Config != null && !string.IsNullOrEmpty(Config.AccountSidWhatsApp) && !string.IsNullOrEmpty(Config.TokenWhatsapp) && !string.IsNullOrEmpty(Config.CelularContato) && !string.IsNullOrEmpty(celularMorador))
            {
                var accountSid = Config.AccountSidWhatsApp;
                var authToken = Config.TokenWhatsapp;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber($"whatsapp:+55{celularMorador}"));
                messageOptions.From = new PhoneNumber($"whatsapp:+55{Config.CelularContato}");
                messageOptions.Body = $"Condsys: Entrada do visitante {nomeVisitante} em {DateTime.Now.ToString("dd/MM/yyyy")} as {DateTime.Now.ToString("HH:mm")}";

                var message = MessageResource.Create(messageOptions);
            }
        }
    }
}
