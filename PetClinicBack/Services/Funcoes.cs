using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace PetDoor.Services
{

    public class Funcoes
    {
        public static bool ValidarCpf(string cpf)
        {
            //int cpfNum = int.Parse(cpf);
            int[] numerosCpf = new int[11];
            int index = 0;
            foreach(char c in cpf)
            {
                numerosCpf[index] = int.Parse(c.ToString());
                index++;
            }
            // validação primeiro digito 
            int primeiroDigito = ((numerosCpf[0] * 10 + numerosCpf[1] * 9 +
                numerosCpf[2] * 8 + numerosCpf[3] * 7 + numerosCpf[4] * 6
                + numerosCpf[5] * 5 + numerosCpf[6] * 4 + numerosCpf[7] * 3 +
                numerosCpf[8] * 2) * 10 ) % 11;

            if(primeiroDigito == 10)
                primeiroDigito = 0;

            if(primeiroDigito != numerosCpf[9])
                return false;

            // validação segundo digito 
            int segundoDigito = ((numerosCpf[0] * 11 + numerosCpf[1] * 10 +
                numerosCpf[2] * 9 + numerosCpf[3] * 8 + numerosCpf[4] * 7
                + numerosCpf[5] * 6 + numerosCpf[6] * 5 + numerosCpf[7] * 4 +
                numerosCpf[8] * 3 + numerosCpf[9] * 2) * 10 ) % 11;

            if (segundoDigito == 10)
                segundoDigito = 0;

            if (segundoDigito != numerosCpf[10])
                return false;

            return true;
        }

        public static bool ValidarCep(string Cep)
        {
            string url = "https://viacep.com.br";
            string endpoint = $"/ws/{Cep}/json/";
            string method = "Get";
            Dictionary<string, string> headers = new Dictionary<string, string>();

            RestResponse response = ConsumirApi<RestResponse>(url, endpoint, method, headers);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;

            return false;
        }

        public static RestResponse<T> ConsumirApi<T>(string baseUrl, string endpoint, string method, Dictionary<string, string> headers, object payload = null) where T : new()
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, (Method)Enum.Parse(typeof(Method), method));

            // Add headers
            foreach (var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            if (payload != null)
            {
                request.AddJsonBody(payload);
            }

            RestResponse<T> response =  client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }

            return response;
        }

        public static void enviarEmail(string email, string titulo, string mensagem)
        {
            try
            {
                MailMessage newMail = new MailMessage();
                // use the Gmail SMTP Host
                SmtpClient client = new SmtpClient("smtp.gmail.com");

                // Follow the RFS 5321 Email Standard
                newMail.From = new MailAddress("petdorpcs@gmail.com", "PetD'or");

                newMail.To.Add(email);// declare the email subject

                newMail.Subject = titulo; // use HTML for the email body

                newMail.IsBodyHtml = true; newMail.Body = mensagem;

                // enable SSL for encryption across channels
                client.EnableSsl = true;
                // Port 465 for SSL communication
                client.Port = 587;
                // Provide authentication information with Gmail SMTP server to authenticate your sender account
                client.Credentials = new System.Net.NetworkCredential("petdorpcs@gmail.com", "UNIRIO123");

                client.Send(newMail); // Send the constructed mail
                Console.WriteLine("Email Sent");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error -" + ex);
            }
        }
        
    }
}
