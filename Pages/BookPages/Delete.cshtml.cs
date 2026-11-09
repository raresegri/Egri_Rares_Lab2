
using Egri_Rares_Lab2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Egri_Rares_Lab2.Pages.BookPages;

[Authorize(Roles = "Admin")]

public class DeleteModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;

    public DeleteModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Authors)
            .FirstOrDefaultAsync(b => b.ID == id);

        if (book is null)
        {
            return NotFound();
        }

        Book = book;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var book = await _context.Book.FindAsync(id);

        if (book is not null)
        {
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
