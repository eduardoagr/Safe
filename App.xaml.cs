using Syncfusion.Licensing;

using System.Windows;

namespace Safe {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        public static string UserId = string.Empty;
        public static string region = "westeurope";
        public static string azureSpeeshKey = "2ac1fba0bf9d40bca76d17fd0a94d69e";
        public static string azureStorageKey = "DefaultEndpointsProtocol=https;AccountName=safestoragewpf;AccountKey=cQzJszXHiEzM3Eng1mfIagQNUg8MJNE1YofoNOOwuRVCK7qmkcpeHCuapAy93j3oddjxxcLYq+dVCE3EEhgDCw==;EndpointSuffix=core.windows.net";

            public App() {
            //Register Syncfusion license
             SyncfusionLicenseProvider.RegisterLicense("NDQzMjgyQDMxMzkyZTMxMmUzMFBXTkhGZ2hSRmVQZENVTTZ6RXdoaTFqdytuYyt3TW0yVUdYTy9Xd0dGeEU9");
        }

    }
}
