using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kernel.Stubs;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Kernel.Services
{
    class GetFlatUpdate : IGetFlatUpdate
    {
        private string _RestServiceUrl { get; set; }

        public GetFlatUpdate(String restServiceUrl)
        {
            this._RestServiceUrl = restServiceUrl;
        }

        public async Task<EventbusMessage> GetFlatConfig()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_RestServiceUrl)
            };
            //accept JSON HEADER
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Retrieve flat config
            var response = await client.GetAsync("flat");

            //Exception if something went wrong...
            response.EnsureSuccessStatusCode();

            String jsonString = await response.Content.ReadAsStringAsync();
            IJsonUtils iju = new JsonUtils();
            EventbusMessage ebm = iju.convertfromJson(jsonString);
            return ebm;

        }
    


        

}
}
