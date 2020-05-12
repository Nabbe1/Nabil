using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using NabilsRondSystem.Models;
using NabilsRondSystem.ViewModels;
using Rg.Plugins.Popup.Extensions;

namespace NabilsRondSystem
{
    public partial class MainPage : ContentPage
    {
        ZXingScannerPage scanPage;
        private NabilsRondSystem.IRondservice _service;

        string User = "";
        string Plats = "";
        string Time;
        string Date;
        string Felrapport = "";
        private InsertSetting vm;
        public MainPage()
        {
            InitializeComponent();

            btnScanDefault.Clicked += btnScanDefault_Clicked;

            this.vm = new InsertSetting();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //PopulateURLEntry();
            _service = DependencyService.Get<IRondservice>();
        }



        private async void btnScanDefault_Clicked(object sender, EventArgs e)
        {

            if (entuser.Text.Equals(""))
            {
                await DisplayAlert("Ingen användare", "Du måste ange en användare...", "ok");
                return;
            }
            else
            {
                User = entuser.Text;

            }

            scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) => {


                // Stops scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    DateTime dt = DateTime.Now;
                    Navigation.PopModalAsync();
                    DisplayAlert("Scanned Barcode starts with: " + result.Text.Remove(2), result.Text, "OK Nice Nabz: " + result.Text.Length);
                    Plats = result.ToString();
                    entplats.Text = result.ToString();
                    Time = dt.ToString("HH:mm"); //Timmar, minuter
                    Date = dt.ToString("yyyy-MM-dd"); // Datum


                    vm.SaveToLocaldb(result.ToString());

                });
            };

            await Navigation.PushModalAsync(scanPage);
        }

        private void BtnListall_Clicked(object sender, EventArgs e)
        {
            // webservice är kopplat och skriver
            // mina värden till SQL och Sharepoint
            try
            {
                Felrapport = entfelrapport.Text;
                //string Plats = "Källaren";
                //string Time = "12:12";
                //string Date = "2019-03-12";
                //string Felrapport = "Det funkar härifrån";
                //string Anvandare = "Nabil Benali";
                string resultat = _service.TestInsert(Plats, Time, Date, Felrapport, User);

                entuser.Text = "";
                entplats.Text = "";
                entfelrapport.Text = "";


            }
            catch (Exception ex)
            {
                DisplayAlert("åsna", ex.StackTrace, ex.Message);
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new LoginPopupPage());
        }

        //private void BtnSaveURL_Clicked(object sender, EventArgs e)
        //{
        //    vm.conn.Execute("update settings set value='" + EntryWebservice.Text + "' where key='websvc'");
        //}
        //public void PopulateURLEntry()
        //{
        //    var KeyForUrl = vm.conn.Query<Models.Settings>("select value from settings where key='websvc'");
        //    string URL = "";
        //    foreach (var key in KeyForUrl)
        //    {
        //        URL = key.Value;
        //    }
        //    EntryWebservice.Text = URL;
        //}


    }
}
