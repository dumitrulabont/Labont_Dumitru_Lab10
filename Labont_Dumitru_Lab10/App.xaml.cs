using System;
using Labont_Dumitru_Lab10.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;


namespace Labont_Dumitru_Lab10
{
    public partial class App : Application
    {
        static ShopingListDatabase database;
        public static ShopingListDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new ShopingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShopingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
