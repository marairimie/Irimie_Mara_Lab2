using Microsoft.EntityFrameworkCore;

public class Irimie_Mara_Lab2Context(DbContextOptions<Irimie_Mara_Lab2Context> options) : DbContext(options)
{
    public DbSet<Irimie_Mara_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Irimie_Mara_Lab2.Models.Publisher> Publisher { get; set; } = default!;

    public DbSet<Irimie_Mara_Lab2.Models.Author> Author { get; set; } = default!;
}
