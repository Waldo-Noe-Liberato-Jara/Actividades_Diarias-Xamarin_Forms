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
    public partial class VAgregar : ContentPage
    {
        public VAgregar()
        {
            InitializeComponent();
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            Agregar_Actividad();
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Regresar();
        }
        async void Agregar_Actividad()
        {
            

            await App.Db_Actividades.Guardar_Actividad_Async(new Modelo.MActividad()
            {
                
                Actividad = Validar(),
                Fecha_Inicio = TxtFechaInicio.Date.ToString("dd-MM-yyyy"),
                Fecha_Fin = TxtFechaFin.Date.ToString("dd-MM-yyyy"),
                Fecha_Creacion = DateTime.Parse(DateTime.Now.ToString("dd-MM-yyyy")).ToString("dd-MM-yyyy")
            });

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
    }
}