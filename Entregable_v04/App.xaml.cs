using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Entregable_v04.Datos;
using Entregable_v04.Vista;
using Plugin.SharedTransitions;

namespace Entregable_v04
{
    public partial class App : Application
    {
        private static SQLiteHelper _Db_Actividades;
        public static SQLiteHelper Db_Actividades
        {
            get
            {
                if(_Db_Actividades == null)
                {
                    _Db_Actividades = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Actividades.db3"));
                }
                return _Db_Actividades;
            }
        }

        public App()
        {
            InitializeComponent();
            //MainPage = new MainPage();
            MainPage = new SharedTransitionNavigationPage(new VActividades());
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
