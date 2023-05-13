using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Invoices
{
    public class IndexModel : PageModel
    {
        private readonly SupermarketContext _context;
        public IndexModel(SupermarketContext context)
        {
            _context = context;
        }

        public IList<Invoice> Invoices { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Invoices != null)
            {
                Invoices = await _context.Invoices.ToListAsync();
            }
        }
    }
}
