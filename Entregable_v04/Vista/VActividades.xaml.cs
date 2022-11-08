using Entregable_v04.Modelo;
using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Entregable_v04.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VActividades : ContentPage
    {
        public static List<MActividad> nueva_lista { get; set; } = new List<MActividad>();
        public VActividades()
        {
            InitializeComponent();
        }
        //Listar Actividad de forma asíncrona
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                LV_Actividades.ItemsSource = await App.Db_Actividades.Listar_Actividades_Async();
                //Controla cantidad de Actividades
                nueva_lista.Clear();
                nueva_lista = await App.Db_Actividades.Listar_Actividades_Async();
            }
            catch
            {
                
            }
        }
        //Agregar Actividad
        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            if (nueva_lista.Count >= 0 && nueva_lista.Count <= 9)
            {
                var page = (App.Current.MainPage as SharedTransitionNavigationPage).CurrentPage;
                SharedTransitionNavigationPage.SetBackgroundAnimation(page, BackgroundAnimation.SlideFromRight);
                SharedTransitionNavigationPage.SetTransitionDuration(page, 1000);
                await Navigation.PushAsync(new VAgregar());
            }
            else
            {
                await DisplayAlert("Mensaje", "No puede agregar más de 10 actividades.", "Entendido");
            }

        }
        //Actualizar Actividad
        async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var a = item.CommandParameter as MActividad;
            await Navigation.PushAsync(new VActualizar(a));
        }
        //Eliminar Actividad
        async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var act = item.CommandParameter as MActividad;
            await App.Db_Actividades.Eliminar_Actividad_Async(act);
            LV_Actividades.ItemsSource = await App.Db_Actividades.Listar_Actividades_Async();
            //Controla cantidad de Actividades
            nueva_lista.Clear();
            nueva_lista = await App.Db_Actividades.Listar_Actividades_Async();
        }
        //Buscar Actividad
        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue != "")
            {
                LV_Actividades.ItemsSource = await App.Db_Actividades.Buscar_Actividad(e.NewTextValue);
            }
            else
            {
                LV_Actividades.ItemsSource = await App.Db_Actividades.Listar_Actividades_Async();
            }
        }
    }
}