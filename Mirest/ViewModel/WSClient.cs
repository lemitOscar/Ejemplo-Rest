using System;
using System.Collections.Generic;
using System.Text;

namespace Mirest.ViewModel
{
    using Mirest.Models;
    using Mirest.Services;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    class WSClient : BaseViewModel
    {
        #region properties collectionlist
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
        #endregion
       
        #region properties Commands
        public Command llamarbtn { get; set; }
        #endregion
        
        public WSClient()
        {
            llamarbtn = new Command(RecibirRest);
        }
        public async void RecibirRest()
        {
            Datos = new ObservableCollection<PostModel>();
            ServiceRestHelper client = new ServiceRestHelper();
            var result = await client.Get<PostModel>("https://jsonplaceholder.typicode.com/posts/1");
            Datos.Add(result);
        }



    }
}
