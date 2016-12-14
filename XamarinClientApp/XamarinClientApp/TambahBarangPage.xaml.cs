using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class TambahBarangPage : ContentPage
    {
        public TambahBarangPage()
        {
            InitializeComponent();

            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
        }

        private RestClient _client =
            new RestClient("http://derrystokapp.azurewebsites.net/");

        private async void BtnTambahBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/barang", Method.POST);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                KategoriId = Convert.ToInt32(txtKategoriId.Text),
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                Nama = txtNama.Text,
                Stok = Convert.ToInt32(txtStok.Text),
                HargaBeli = Convert.ToInt32(txtHargaBeli.Text),
                HargaJual = Convert.ToInt32(txtHargaJual.Text),
                TanggalBeli = txtTanggalBeli.Date
            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
