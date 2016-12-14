using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinClientApp.Models;
using RestSharp;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp.ViewModels
{
    public class SearchKategori : BindableObject
    {
        private RestClient _client =
            new RestClient("http://derrystokapp.azurewebsites.net/");

        private ObservableCollection<BarangVM> listBarangVM;
        public ObservableCollection<BarangVM> ListBarangVM
        {
            get { return listBarangVM; }
            set { listBarangVM = value; OnPropertyChanged("ListBarangVM"); }
        }

        private async void RefreshDataAsync(string Nama)
        {
            RestRequest _request = new RestRequest("api/viewbarkat?Nama=" + Nama, Method.GET);
            var _response = await _client.Execute<List<BarangVM>>(_request);
            ListBarangVM = new ObservableCollection<BarangVM>(_response.Data);
        }

        public SearchKategori(string Nama)
        {
            RefreshDataAsync(Nama);
        }
    }
}
