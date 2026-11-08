using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.MemberPages;

public class IndexModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;

    public IndexModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    public IList<Member> Member { get; set; } = default!;

    public async Task OnGetAsync()
    {   
        Member = await _context.Member
        .Include(m => m.Borrowings)
        .ThenInclude(b => b.Book)
        .ToListAsync();
    }
}
