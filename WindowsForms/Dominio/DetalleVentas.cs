using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    internal class DetalleVentas
    {
        private int Id_Detalle { get; set; }
        private Ventas Ventas { get; set; }
        private Productos Productos { get; set; }
        private int Cantidad { get; set; }
        private int Precio {  get; set; }

    }
}
