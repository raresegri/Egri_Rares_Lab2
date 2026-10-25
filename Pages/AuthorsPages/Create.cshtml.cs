
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.AuthorsPages
{
    public class CreateModel : PageModel
    {
        private readonly Egri_Rares_Lab2Context _context;

        public CreateModel(Egri_Rares_Lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Authors Authors { get; set; } = new Authors();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Authors.Add(Authors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
