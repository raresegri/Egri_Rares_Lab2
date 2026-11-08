using Microsoft.EntityFrameworkCore;

public class Egri_Rares_Lab2Context(DbContextOptions<Egri_Rares_Lab2Context> options) : DbContext(options)
{
    public DbSet<Egri_Rares_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.Authors> Authors { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.Category> Category { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.BookCategory> BookCategory { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.AssignedCategoryData> AssignedCategoryData { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.Member> Member { get; set; } = default!;
    public DbSet<Egri_Rares_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
}
