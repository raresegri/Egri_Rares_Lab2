
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.BorrowingPages;

public class DeleteModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;

    public DeleteModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .Include(b => b.Member)
            .Include(b => b.Book)
                .ThenInclude(b => b.Authors)
            .Include(b => b.Book)
                .ThenInclude(b => b.Publisher)
            .FirstOrDefaultAsync(m => m.ID == id);

        if (borrowing == null)
        {
            return NotFound();
        }

        Borrowing = borrowing;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing.FindAsync(id);

        if (borrowing != null)
        {
            _context.Borrowing.Remove(borrowing);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
