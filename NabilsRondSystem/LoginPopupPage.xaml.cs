using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabilsRondSystem.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NabilsRondSystem.ViewModels;

namespace NabilsRondSystem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPopupPage : PopupPage
	{
        private InsertSetting vm;
		public LoginPopupPage ()
		{
           
			InitializeComponent ();
            this.vm = new InsertSetting();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            PopulateURLEntry();

        }
        
        private void Btnurl_Clicked(object sender, EventArgs e)
        {
            vm.conn.Execute("update settings set value='" + entwebsvc.Text.Trim() + "' where key='websvc'");
        }

        public void PopulateURLEntry()
        {
            var KeyForUrl = vm.conn.Query<Models.Settings>("select value from settings where key='websvc'");
            string URL = "";
            foreach (var key in KeyForUrl)
            {
                URL = key.Value;
            }
            entwebsvc.Text = URL;
        }
    }
}