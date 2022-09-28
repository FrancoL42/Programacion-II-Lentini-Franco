using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Recetas
    {
        public int Receta { get; set; }
        public string Nombre { get; set; }
        public int TipoReceta { get; set; }
        public string Cheff { get; set; }
        public  List<DetalleReceta> detallesReceta;
        public Recetas(int receta, string nombre, int tipoReceta, string cheff)
        {
            Receta = receta;
            Nombre = nombre;
            TipoReceta = tipoReceta;
            Cheff = cheff;
        }
        public void agregarDetalle(DetalleReceta detalle)
        {
            detallesReceta.Add(detalle);
        }
        public void EliminarDetalle(int id)
        {
            detallesReceta.RemoveAt(id);    
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
