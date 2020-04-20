using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
namespace Covid19.Controller
{
    public class ConnectivityTest
    {
        public ConnectivityTest()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            var profiles = e.ConnectionProfiles;
        }
        public bool CheckInternet()
        {
            bool value = false;
            var current = Connectivity.NetworkAccess;
            if (current==NetworkAccess.Internet)
            {
                value= true;
            }
            return value;
        }
    }
}
