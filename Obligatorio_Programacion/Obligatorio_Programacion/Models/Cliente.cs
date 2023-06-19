using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class Cliente
{
    public string Cedula { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
