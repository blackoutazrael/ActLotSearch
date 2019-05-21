using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LotSearch.Util
{
    class HttpHelper
    {
        #region コンストラクタ
        public HttpHelper()
        {
        }
        #endregion コンストラクタ

        public async Task<string> DoPostAsync(string json, string uri, bool isForDiscord)
        {
            using (var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) })
            {
                if (isForDiscord)
                {
                    client.DefaultRequestHeaders.Add("Authorization", STRINGSTOCK.AUTH_CODE_ALFRED.GetStringValue());
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                }
                
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                //else if((int)response.StatusCode >= 400)
                else
                {
                    return "error";
                }
            }

        }
    }
}
