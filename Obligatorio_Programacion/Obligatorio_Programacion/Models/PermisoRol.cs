using System;
using System.Collections.Generic;

namespace Obligatorio_Programacion.Models;

public partial class PermisoRol
{
    public int? IdPermisoRol { get; set; }

    public int? IdRolPermiso { get; set; }

    public virtual Permiso? IdPermisoRolNavigation { get; set; }

    public virtual Rol? IdRolPermisoNavigation { get; set; }
}
