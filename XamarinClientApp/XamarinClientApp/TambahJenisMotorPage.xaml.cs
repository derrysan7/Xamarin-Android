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
    public partial class TambahJenisMotorPage : ContentPage
    {
        public TambahJenisMotorPage()
        {
            InitializeComponent();

            btnTambahJenisMotor.Clicked += BtnTambahJenisMotor_Clicked;
        }

        private RestClient _client =
            new RestClient("http://derrystokapp.azurewebsites.net/");

        private async void BtnTambahJenisMotor_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/jenismotor", Method.POST);
            var newJenisMotor = new JenisMotor { NamaMerk = txtNamaMerk.Text , NamaJenisMotor = txtJenisMotor.Text};
            _request.AddBody(newJenisMotor);
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
