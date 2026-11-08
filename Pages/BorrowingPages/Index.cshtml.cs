using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.BorrowingPages;

public class IndexModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;

    public IndexModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    public IList<Borrowing> Borrowing { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Borrowing != null)
        {
            Borrowing = await _context.Borrowing
            .Include(b => b.Book)
            .ThenInclude(b => b.Authors)
            .Include(b => b.Member).ToListAsync();
        }
    }
}
