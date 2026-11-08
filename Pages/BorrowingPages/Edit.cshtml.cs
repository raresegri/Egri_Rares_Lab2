using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.BorrowingPages;

public class EditModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;

    public EditModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    public SelectList MemberList { get; set; } = default!;
    public SelectList BookList { get; set; } = default!;

    private async Task LoadListsAsync()
    {
        MemberList = new SelectList(
            await _context.Member
                .Select(m => new
                {
                    m.ID,
                    FullName = m.FirstName + " " + m.LastName
                })
                .ToListAsync(),
            "ID",
            "FullName"
        );

        BookList = new SelectList(
            await _context.Book
                .Select(b => new
                {
                    b.ID,
                    DisplayName = b.title
                })
                .ToListAsync(),
            "ID",
            "DisplayName"
        );
    }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var borrowing = await _context.Borrowing
            .FirstOrDefaultAsync(m => m.ID == id);

        if (borrowing == null)
        {
            return NotFound();
        }

        Borrowing = borrowing;

        await LoadListsAsync();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadListsAsync();
            return Page();
        }

        _context.Attach(Borrowing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BorrowingExists(Borrowing.ID))
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

    private bool BorrowingExists(int id)
    {
        return _context.Borrowing.Any(e => e.ID == id);
    }
}
