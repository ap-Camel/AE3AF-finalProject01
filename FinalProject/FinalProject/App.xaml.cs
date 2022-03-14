using FinalProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FinalProject.Services;
using System.IO;

namespace FinalProject
{
    public partial class App : Application
    {
        private static LocalDbServices dbContext;

        public static LocalDbServices DbContext
        {
            get
            {
                if (dbContext == null)
                {
                    string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "ShoppingListDatabase-v01.db3");

                    dbContext = new LocalDbServices(dbPath);
                }

                return dbContext;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
