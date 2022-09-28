using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class DetalleReceta
    {
        public Ingrediente Ingrediente { get; set; }
        public decimal Cantidad { get; set; }
        public DetalleReceta(Ingrediente ingrediente, decimal cantidad)
        {
            this.Ingrediente = ingrediente;
            this.Cantidad = cantidad;           
        }
        public override string ToString()
        {
            return Ingrediente.ToString() + " | " + Cantidad;
        }
    }
}
