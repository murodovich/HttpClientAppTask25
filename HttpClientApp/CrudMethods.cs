using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientApp
{
    public class CrudMethods
    {
        string url = "https://localhost:7153/api/Products/Categories";


        public async Task<string> GetAllAsync()
        {
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetAsync(url).Result.Content.ReadAsStringAsync();

            }
            return json;
        }
        public async Task<string> GetByIdAsync(int id)
        {
            string query = string.Format("https://localhost:7153/api/Products/Categories/{0}", id);
            string json;
            using (HttpClient client = new HttpClient())
            {
                json = await client.GetAsync(query).Result.Content.ReadAsStringAsync();
            }
            return json;
        }
        public async Task<string> PostAsync(string CategoryName)
        {

            string response;
            var json = JsonConvert.SerializeObject(CategoryName);
            var maindata = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(url, maindata).Result.Content.ReadAsStringAsync();
                //response = await client.PostAsJsonAsync(url, data).Result.Content.ReadAsStringAsync();
            }
            return response;
        }
        public async Task<string> DeleteAsync(int id)
        {
            string response = "";
            using (HttpClient client = new HttpClient())
            {
                string query = string.Format("https://localhost:7153/api/Products/Categories/{0}", id);
                var res = await client.DeleteAsync(query);
            }
            return response;
        }
        public async Task<string> PutAsync(int id, string name)
        {


            string response = "";

            using (HttpClient client = new HttpClient())
            {
                string query = string.Format("https://localhost:7153/api/Products/Categories/{0}?name={1}", id, name);
                var data = new StringContent(query, Encoding.UTF8, "application/json");
                response = await client.PutAsync(query, data).Result.Content.ReadAsStringAsync();
            }
            return response;

        }

    }
}
