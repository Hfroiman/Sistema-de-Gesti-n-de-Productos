using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public string Codigo { get; set; }
        public string IMG { get; set; }
        public string Nombre{ get; set; }
        public Colores Colores { get; set; }
        public Talles Talles { get; set; }
        public Marcas Marcas { get; set; }
        public Tipo_Productos Tipo_Productos { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
