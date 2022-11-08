using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Entregable_v04.Modelo;
using System.Threading.Tasks;

namespace Entregable_v04.Datos
{
    public class SQLiteHelper
    {
        public readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<MActividad>();
        }
        public Task<int> Guardar_Actividad_Async(MActividad actividad)
        {
                return db.InsertAsync(actividad);
        }
        public Task<List<MActividad>> Listar_Actividades_Async()
        {
            return db.Table<MActividad>().ToListAsync();
        }
        public Task<int> Actualizar_Actividad_Async(MActividad actividad)
        {
            return db.UpdateAsync(actividad);
        }
        public Task<int> Eliminar_Actividad_Async(MActividad actividad)
        {
            return db.DeleteAsync(actividad);
        }
        public Task<List<MActividad>> Buscar_Actividad(string actividad)
        {
            string a = actividad.Substring(0,1).ToUpper();
            string b = actividad.Substring(1);
            string act = a + b;
            return db.Table<MActividad>().Where(p => p.Actividad.StartsWith(act)).ToListAsync();
        }

        /*public readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<MActividad>().Wait();
        }
        public Task<int> Guardar_Actividad_Async(MActividad actividad)
        {
            if (actividad.ID_Actividad != 0)
            {
                return db.UpdateAsync(actividad);
            }
            else
            {
                return db.InsertAsync(actividad);
            }
        }
        public Task<int> Eliminar_Actividad_Async(MActividad actividad)
        {
            return db.DeleteAsync(actividad);
        }
        public Task<List<MActividad>> Listar_Actividades_Async()
        {
            return db.Table<MActividad>().ToListAsync();
        }
        public Task<MActividad> Obtener_ID_Actividad_Async(int Id_Actividad)
        {
            return db.Table<MActividad>().Where(a => a.ID_Actividad == Id_Actividad).FirstOrDefaultAsync();
        }*/
    }
}
