using Irimie_Mara_Lab2.Models;
using Irimie_Mara_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Irimie_Mara_Lab2.Pages.PublisherPages;

public class IndexModel : PageModel
{
    private readonly Irimie_Mara_Lab2Context _context;

    public IndexModel(Irimie_Mara_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public PublisherIndexData PublisherData { get; set; } 
    public int PublisherID { get; set; }
    public int BookID { get; set; }

    public async Task OnGetAsync(int? id, int? bookID)
    {
        PublisherData = new PublisherIndexData();
        PublisherData.Publishers = await _context.Publisher
            .Include(i => i.Books)
                .ThenInclude(C => C.Author)
            .OrderBy(i => i.PublisherName)
            .ToListAsync();

        if (id != null)
        {
            PublisherID = id.Value;
            Publisher publisher = PublisherData.Publishers
                .Where(i => i.ID == id.Value).Single();
            PublisherData.Books = publisher.Books;
        }
    }
}
