
using Egri_Rares_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Egri_Rares_Lab2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Egri_Rares_Lab2Context _context;

        public IndexModel(Egri_Rares_Lab2Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publishers { get; set; } = new List<Publisher>();

        public async Task OnGetAsync()
        {
            Publishers = await _context.Publisher
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
