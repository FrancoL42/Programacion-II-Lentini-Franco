using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Ingrediente
    {
        public int IngredienteId { get; set; }
        public string Nombre { get; set; }
        public string Unidad { get; set; }
        public Ingrediente(int id, string nombre, string unidad)
        {
            IngredienteId = id;
            Nombre = nombre;
            Unidad = unidad;
        }
        public override string ToString()
        {
            return Nombre + " | " + Unidad;
        }
    }
}
