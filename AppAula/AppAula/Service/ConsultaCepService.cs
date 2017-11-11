using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAula.Model;

using Newtonsoft.Json;
using System.Net.Http;

namespace AppAula.Service
{
    class ConsultaCepService
    {

        public ConsultaCepService()
        {

        }

        private static string UrlBase = "https://viacep.com.br/ws/{0}/json/";

        //public async static Task<string> BuscaCep(string Cep)
        public async static Task<Cep> BuscaCep(string cep)
        {
            //string URL = string.Format(UrlBase,Cep);
            string URL = string.Format(UrlBase, cep);
            HttpClient http = new HttpClient();
            string Json = await http.GetStringAsync(URL);

/*            dynamic objetoCep = JsonConvert.DeserializeObject<dynamic>(Json);

            string resultado = string.Format("CEP={0} UF={1} LOGRADOURO={2}",objetoCep.cep,objetoCep.uf,objetoCep.logradouro);

            return resultado;*/

            Cep objetoCep = JsonConvert.DeserializeObject<Cep>(Json);

           

            return objetoCep;
        }

    }
}
