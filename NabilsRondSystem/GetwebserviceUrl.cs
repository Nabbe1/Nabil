using System;
using System.Collections.Generic;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(NabilsRondSystem.GetwebserviceUrl))]

namespace NabilsRondSystem
{
    class GetwebserviceUrl : IGetwebserviceUrl
    {
        private ViewModels.InsertSetting vm;


        public GetwebserviceUrl()
        {
            this.vm = new ViewModels.InsertSetting();
        }
        public string GetWebsvcUrlFromSqlite()
        {
            string url = "";
            var URLlist = vm.conn.Query<Models.Settings>("select value from settings where key='websvc'");
            foreach (var adress in URLlist)
            {
                url = adress.Value;
            }
            return url;
        }
    }
}