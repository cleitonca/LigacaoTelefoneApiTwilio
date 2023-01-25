using Twilio.Types;
using Twilio;
using System.Text;
using Twilio.Rest.Api.V2010.Account;

const string accountSid = "AC55cb2ff4176e9ce81057fe08bd2920ba"; // SID gerado no site da Twilio
const string authToken = "Digite aqui o Token gerado no site da Twilio";

TwilioClient.Init(accountSid, authToken);

var telefoneDestino = new PhoneNumber("+14155551212"); // Telefone que vai receber a ligação
var telefoneTwilio = new PhoneNumber("+15017122661"); // Telefone cadastrado no Twilio

StringBuilder mensagem = new StringBuilder();

// O que vai ser falado na ligação:
mensagem.AppendLine("<Response>"); 
    mensagem.AppendLine("<Say language='pt-BR'>");
        mensagem.AppendLine("Oi meu amor, você pediu para te acordar!");
        mensagem.AppendLine("Bora levantar e fazer o pão que você falou que ia fazer.");
        mensagem.AppendLine("Te amo!");
    mensagem.AppendLine("</Say>");
mensagem.AppendLine("</Response>");

var ligacao = CallResource.Create(
    to: telefoneDestino, 
    from: telefoneTwilio,
    twiml: mensagem.ToString());

Console.WriteLine(ligacao.Sid);