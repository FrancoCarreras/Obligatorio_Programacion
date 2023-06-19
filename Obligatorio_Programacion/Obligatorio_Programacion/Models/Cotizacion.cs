using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class Cotizacion
{
    public int IdCotizacion { get; set; }

    public double? PrecioPesos { get; set; }

    public double? PrecioDolar { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
