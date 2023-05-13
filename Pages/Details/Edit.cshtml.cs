using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Details
{
    public class EditModel : PageModel
    {
        private readonly SupermarketContext _context;
        public EditModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Detail Detail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Details == null)
            {
                return NotFound();
            }
            var detail = await _context.Details.FirstOrDefaultAsync(m => m.Id == id);

            if (detail == null)
            {
                return NotFound();
            }

            Detail = detail;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Detail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!DetailExists(Detail.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return RedirectToPage("./Index");
        }
        private bool DetailExists(int id)
        {
            return (_context.Details?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
