
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.AuthorsPages
{
    public class DetailsModel : PageModel
    {
        private readonly Egri_Rares_Lab2Context _context;

        public DetailsModel(Egri_Rares_Lab2Context context)
        {
            _context = context;
        }

        public Authors Authors { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(a => a.ID == id);

            if (authors == null)
            {
                return NotFound();
            }

            Authors = authors;
            return Page();
        }
    }
}
