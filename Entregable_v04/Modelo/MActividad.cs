using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Entregable_v04.Modelo
{
    public class MActividad
    {
        private int _ID_Actividad;
        private string _Actividad;
        private string _Fecha_Inicio;
        private string _Fecha_Fin;
        private string _Fecha_Creacion;

        [PrimaryKey, AutoIncrement]
        public int ID_Actividad
        {
            get { return _ID_Actividad; }
            set { _ID_Actividad = value; }
        }
        [MaxLength(50)]
        public string Actividad
        {
            get { return _Actividad; }
            set { _Actividad = value; }
        }
        [MaxLength(50)]
        public string Fecha_Inicio
        {
            get { return _Fecha_Inicio; }
            set { _Fecha_Inicio = value; }
        }
        [MaxLength(50)]
        public string Fecha_Fin
        {
            get { return _Fecha_Fin; }
            set { _Fecha_Fin = value; }
        }
        [MaxLength(50)]
        public string Fecha_Creacion
        {
            get { return _Fecha_Creacion; }
            set { _Fecha_Creacion = value; }
        }
    }
}
