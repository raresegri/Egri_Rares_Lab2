
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.AuthorsPages
{
    public class EditModel : PageModel
    {
        private readonly Egri_Rares_Lab2Context _context;

        public EditModel(Egri_Rares_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var authorToUpdate = await _context.Authors
                .FirstOrDefaultAsync(a => a.ID == Authors.ID);

            if (authorToUpdate == null)
            {
                return NotFound();
            }

            authorToUpdate.FirstName = Authors.FirstName;
            authorToUpdate.LastName = Authors.LastName;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
