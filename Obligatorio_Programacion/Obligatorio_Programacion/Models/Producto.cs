using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Descripcion { get; set; }

    public double? Precio { get; set; }

    public int? Stock { get; set; }

    public virtual ICollection<LineaFactura> LineaFacturas { get; set; } = new List<LineaFactura>();
}
