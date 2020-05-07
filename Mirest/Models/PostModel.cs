using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Mirest.Models
{
    public class PostModel
    {
        #region Properties
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        #endregion
       
    }
}
