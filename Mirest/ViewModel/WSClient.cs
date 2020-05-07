using System;
using System.Collections.Generic;
using System.Text;

namespace Mirest.ViewModel
{
    using Mirest.Models;
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Net.Http;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    class WSClient : BaseViewModel
    {
        public Command llamarbtn { get; set; }

        public WSClient()
        {
            llamarbtn = new Command(RecibirRest);
        }

        public async Task<T> Get<T>(string url)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);

        }
        private ObservableCollection<PostModel> _Datos;

        public ObservableCollection<PostModel> Datos
        {
            get { return _Datos; }
            set
            {
                _Datos = value;
                OnPropertyChanged();
            }
        }


        public async void RecibirRest()
        {
            Datos = new ObservableCollection<PostModel>();
            WSClient client = new WSClient();
            var result = await client.Get<PostModel>("https://jsonplaceholder.typicode.com/posts/1");
            Datos.Add(result);
        }
        public ObservableCollection<PostModel> GetDatos()
        {
            return Datos;
        }

    }
}
