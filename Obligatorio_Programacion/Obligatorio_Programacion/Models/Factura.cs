using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public DateTime? Fecha { get; set; }

    public string? CedulaCliente { get; set; }

    public int? IdCotizacion { get; set; }

    public virtual Cliente? CedulaClienteNavigation { get; set; }

    public virtual Cotizacion? IdCotizacionNavigation { get; set; }

    public virtual ICollection<LineaFactura> LineaFacturas { get; set; } = new List<LineaFactura>();
}
