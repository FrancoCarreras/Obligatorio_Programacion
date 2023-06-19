using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class LineaFactura
{
    public int IdLineaFactura { get; set; }

    public int? Cantidad { get; set; }

    public int? IdFactura { get; set; }

    public int? IdProducto { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
