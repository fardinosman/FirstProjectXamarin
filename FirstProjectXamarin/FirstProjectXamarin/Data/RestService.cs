using FirstProjectXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectXamarin.Data
{
    public class RestService
    {
        HttpClient client;
        string grant_type = "password";
        Token Token;
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }
        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));

            var content = new FormUrlEncodedContent(postData);
            var weburl = "www.test.com";
            var response = await PostResponseLogin<Token>(weburl,content);
            DateTime dt = new DateTime();
            dt = DateTime.Today;
            response.expire_date = dt.AddSeconds(response.expire_in);

            return response;
          
        }

        public async Task<T> PostResponseLogin<T>(string weburl ,FormUrlEncodedContent content) where T : class
        {
        
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var resposeObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return resposeObject;
        }

        public async Task<T> PostResponce<T>(string weburl, string jsonstring) where T:class
        {
            var token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var result = await client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if (result.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    var jsonresult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonresult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                    
            
                }
            
            }
            catch
            {
                return null;
            }
            return null;
         

        } 
        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            var response = await client.GetAsync(weburl);
            var jsonresult = response.Content.ReadAsStringAsync().Result;
            var contentResp = JsonConvert.DeserializeObject<T>(jsonresult);
            return contentResp;
        }


    }
}
