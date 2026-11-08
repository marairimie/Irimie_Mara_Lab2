using Irimie_Mara_Lab2.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Irimie_Mara_Lab2Context(DbContextOptions<Irimie_Mara_Lab2Context> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Irimie_Mara_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Irimie_Mara_Lab2.Models.Publisher> Publisher { get; set; } = default!;

    public DbSet<Irimie_Mara_Lab2.Models.Author> Author { get; set; } = default!;

    public DbSet<Irimie_Mara_Lab2.Models.Category> Category { get; set; } = default!;
    public DbSet<Irimie_Mara_Lab2.Models.Member> Member { get; set; } = default!;
    public DbSet<Irimie_Mara_Lab2.Models.Borrowing> Borrowing { get; set; } = default!;
}
