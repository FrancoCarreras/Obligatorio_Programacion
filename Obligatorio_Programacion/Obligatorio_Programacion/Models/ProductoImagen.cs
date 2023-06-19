using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class ProductoImagen
{
    public int? IdProducto { get; set; }

    public int? IdImagen { get; set; }

    public virtual Imagen? IdImagenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
