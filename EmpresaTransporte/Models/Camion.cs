using System;
using System.Collections.Generic;

namespace EmpresaTransporte.Models;

public partial class Camion
{
    public int Id { get; set; }

    public string Marca { get; set; } = null!;

    public string Modelo { get; set; } = null!;

    public int Anio { get; set; }

    public int Kilometraje { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<Mantencion> Mantencions { get; set; } = new List<Mantencion>();

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
