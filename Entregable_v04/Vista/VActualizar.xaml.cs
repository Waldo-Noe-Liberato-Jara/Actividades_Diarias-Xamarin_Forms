using Entregable_v04.Modelo;
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
    public partial class VActualizar : ContentPage
    {
        Modelo.MActividad actividad;
        public VActualizar(MActividad a)
        {
            actividad = a;
            InitializeComponent();
            TxtActividad.Text = actividad.Actividad;
            TxtFechaInicio.Date = DateTime.Parse(actividad.Fecha_Inicio);
            TxtFechaFin.Date = DateTime.Parse(actividad.Fecha_Fin);
        }
        async void Button_Clicked_1(object sender, EventArgs e)
        {
            Actualizar_Actividad();
        }
        async void Actualizar_Actividad()
        {
            actividad.Actividad = Validar();
            actividad.Fecha_Inicio = TxtFechaInicio.Date.ToString("dd-MM-yyyy");
            actividad.Fecha_Fin = TxtFechaFin.Date.ToString("dd-MM-yyyy");
            actividad.Fecha_Creacion = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy")).ToString("dd-MM-yyyy");

            await App.Db_Actividades.Actualizar_Actividad_Async(actividad);
            await Navigation.PopAsync();
        }
        public string Validar()
        {
            string actividad = "Nueva Actividad";
            if (!String.IsNullOrEmpty(TxtActividad.Text))
            {
                string a = TxtActividad.Text.Substring(0, 1).ToUpper();
                string b = TxtActividad.Text.Substring(1);
                actividad = a + b;
            }
            return actividad;
        }
        async void Regresar()
        {
            await Navigation.PopAsync();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Regresar();
        }
    }
}