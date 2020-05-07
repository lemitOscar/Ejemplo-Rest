using System;
using System.Collections.Generic;

using System.Text;


namespace Mirest.Services
{
    using Mirest.Models;
    using Mirest.ViewModel;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class ServiceRestHelper
    {
        
        public ObservableCollection<PostModel> Datos  { get; set; }
        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);

        }
       
    }
}
