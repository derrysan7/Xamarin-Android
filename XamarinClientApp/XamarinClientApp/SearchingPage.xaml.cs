using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.ViewModels;
using XamarinClientApp.Models;
using RestSharp.Portable.HttpClient;
using RestSharp.Portable;

namespace XamarinClientApp
{
    public partial class SearchingPage : ContentPage
    {
        public SearchingPage()
        {
            InitializeComponent();

            btnSearchBarang.Clicked += btnSearchBarang_Clicked;
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new SearchKategori("");
        }

        private void btnSearchBarang_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchKategori(txtSearchBar.Text);
        }
    }
}
