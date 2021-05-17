using System.Windows;

namespace Safe {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        const string KEY = "NDQzMjgyQDMxMzkyZTMxMmUzMFBXTkhGZ2hSRmVQZENVTTZ6RXdoaTFqdytuYyt3TW0yVUdYTy9Xd0dGeEU9";
        public App() {
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(KEY);
        }
    }
}
