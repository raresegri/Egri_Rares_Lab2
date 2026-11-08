
using Egri_Rares_Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Egri_Rares_Lab2.Pages.BorrowingPages;

public class CreateModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;

    public CreateModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    [BindProperty]
    public Borrowing Borrowing { get; set; } = default!;

    private async Task LoadListsAsync()
    {
        var books = await _context.Book
            .Include(b => b.Authors)
            .ToListAsync();

        var bookList = books.Select(b => new
        {
            b.ID,
            BookFullName = b.title + " - " +
                (b.Authors != null
                    ? b.Authors.LastName + " " + b.Authors.FirstName
                    : "Autor necunoscut")
        });

        ViewData["BookID"] = new SelectList(
            bookList, "ID", "BookFullName");

        var members = await _context.Member.ToListAsync();

        var memberList = members.Select(m => new
        {
            m.ID,
            FullName = m.FullName
        });

        ViewData["MemberID"] = new SelectList(
            memberList, "ID", "FullName");
    }

    public async Task<IActionResult> OnGetAsync()
    {
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

        _context.Borrowing.Add(Borrowing);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
