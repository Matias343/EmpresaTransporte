using System;
using System.Collections.Generic;

namespace EmpresaTransporte.Models;

public partial class Mantencion
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public string? Observacion { get; set; }

    public int IdCamion { get; set; }

    public virtual Camion IdCamionNavigation { get; set; } = null!;
}
