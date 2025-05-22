using Microsoft.AspNetCore.Mvc.RazorPages;
using EmpresaTransporte.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmpresaTransporte.Pages.Camiones
{
    public class ListaModel : PageModel
    {
        private readonly SistemaContext _context;

        public ListaModel(SistemaContext context)
        {
            _context = context;
        }

        public List<Camion> Camiones { get; set; } = new();

        public async Task OnGetAsync()
        {
            Camiones = await _context.Camions.ToListAsync();
        }
    }
}