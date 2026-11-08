using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Egri_Rares_Lab2.Models;

namespace Egri_Rares_Lab2.Pages.MemberPages;

public class DetailsModel : PageModel
{
    private readonly Egri_Rares_Lab2Context _context;
    public DetailsModel(Egri_Rares_Lab2Context context)
    {
        _context = context;
    }

    public Member Member { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var member = await _context.Member
            .Include(m => m.Borrowings)
                .ThenInclude(b => b.Book)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (member is null)
        {
            return NotFound();
        }
        else
        {
            Member = member;
        }

        return Page();
    }
}
