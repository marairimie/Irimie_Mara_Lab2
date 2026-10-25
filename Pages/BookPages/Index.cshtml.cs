using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Irimie_Mara_Lab2.Models;

namespace Irimie_Mara_Lab2.Pages.BookPages;

public class IndexModel : PageModel
{
    private readonly Irimie_Mara_Lab2Context _context;

    public IndexModel(Irimie_Mara_Lab2Context context)
    {
        _context = context;
    }
    public int BookID { get; set; }
    public int CategoryID { get; set; }

    public IList<Book> Book { get; set; } = default!;
    public BookData BookD { get; set; }
    public async Task OnGetAsync(int? id, int? categoryId)
    {
        BookD = new BookData();
        
        BookD.Books = await _context.Book
            .Include(b => b.Publisher)
            .Include(b => b.Author)
            .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
        
        if(id  != null)
        {
            BookID = id.Value;
            Book book = BookD.Books
                .Where(b => b.ID == id.Value).Single();
            BookD.Categories = book.BookCategories.Select(bc => bc.Category);
        }
    }
}
