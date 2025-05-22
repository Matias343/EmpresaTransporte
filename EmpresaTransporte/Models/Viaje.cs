using System;
using System.Collections.Generic;

namespace EmpresaTransporte.Models;

public partial class Viaje
{
    public int Id { get; set; }

    public string Destino { get; set; } = null!;

    public int Estado { get; set; }

    public int IdCamion { get; set; }

    public virtual Camion IdCamionNavigation { get; set; } = null!;
}
