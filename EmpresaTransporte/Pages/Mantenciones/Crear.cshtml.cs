using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EmpresaTransporte.Models;
using System.Threading.Tasks;

namespace EmpresaTransporte.Pages.Mantenciones
{
    public class CrearModel : PageModel
    {
        private readonly SistemaContext _context;

        public CrearModel(SistemaContext context)
        {
            _context = context;
        }

        // Bind property para el formulario
        [BindProperty]
        public Mantencion NuevaMantencion { get; set; }

        // Recibimos el Id del camión para asignar la mantención a este camión
        [BindProperty(SupportsGet = true)]
        public int IdCamion { get; set; }

        public void OnGet()
        {
            // Inicializar fecha actual para el input (opcional)
            NuevaMantencion = new Mantencion
            {
                Fecha = DateOnly.FromDateTime(System.DateTime.Today),
                IdCamion = IdCamion
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Mantencions.Add(NuevaMantencion);
            await _context.SaveChangesAsync();

            // Redirigir a la lista de mantenciones o al detalle del camión
            return RedirectToPage("/Camiones/Lista");
        }
    }
}