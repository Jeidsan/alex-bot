using Administrativo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Administrativo.Controllers
{
    public class AlexUpdater
    {
        static string host = "https://westus.api.cognitive.microsoft.com";
        static string service = "/qnamaker/v4.0";
        static string method = "/knowledgebases/";
        static string key = "7d9fb6522d4449f9bab9f998ca2b375f";
        static string kb = "07048516-46f4-444e-a2b1-05f8eb5c9cf0";

        //private static string alexURI = "https://westus.api.cognitive.microsoft.com/qnamaker/v4.0/knowledgebases/07048516-46f4-444e-a2b1-05f8eb5c9cf0";
        //private static string alexKey = "7d9fb6522d4449f9bab9f998ca2b375f"; 

        public async static Task<string> Atualizar(IList<Resposta> respostas)
        {
            var dados = MontaDados(respostas);
            return await Put(host + service + method + kb, dados);
        }

        static string MontaDados(IList<Resposta> respostas)
        {
            string dados = @"{'qnaList': [";

            foreach (var resp in respostas)
            {
                dados += "{ 'id': '" + resp.Id + "', 'answer': '" + resp.Descricao + "', 'questions': [ '" + resp.Pergunta.Descricao + "' ], 'source' : '" + resp.Pergunta.Tema.Descricao + "' }";
            }

            dados += "]}";
            return dados;
        }

        static async Task<string> Put(string uri, String body)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Put;
                request.RequestUri = new Uri(uri);
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", key);

                var response = await client.SendAsync(request);
                return (response.IsSuccessStatusCode ? String.Empty : await response.Content.ReadAsStringAsync());
            }
        }
    }
}
