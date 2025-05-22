using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmpresaTransporte.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace EmpresaTransporte.Pages.Mantenciones
{
    public class Lista : PageModel
    {
        private readonly SistemaContext _context;

        public Lista(SistemaContext context)
        {
            _context = context;
        }

        public List<Mantencion> Mantenciones { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public int IdCamion { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (IdCamion == 0)
            {
                return BadRequest("El IdCamion es obligatorio.");
            }

            Mantenciones = await _context.Mantencions
                .Where(m => m.IdCamion == IdCamion)
                .OrderByDescending(m => m.Fecha)
                .ToListAsync();

            return Page();
        }
    }
}