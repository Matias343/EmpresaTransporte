using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmpresaTransporte.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmpresaTransporte.Pages.Camiones
{
    public class EditarModel : PageModel
    {
        private readonly SistemaContext _context;

        public EditarModel(SistemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Camion Camion { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Camion = await _context.Camions.FindAsync(id);

            if (Camion == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var camionEnDb = await _context.Camions.FindAsync(Camion.Id);

            if (camionEnDb == null)
            {
                return NotFound();
            }

            camionEnDb.Estado = Camion.Estado;

            await _context.SaveChangesAsync();

            return RedirectToPage("Lista");
        }
    }
}