using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Marci
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Marca> Marca { get; set; } = default!;

        public MarcaIndexData MarcaData { get; set; }
        public int MarcaID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            MarcaData = new MarcaIndexData();
            MarcaData.Marci = await _context.Marca
            .Include(i => i.Servicii)
            
            .OrderBy(i => i.NumeMarca)
            .ToListAsync();
            if (id != null)
            {
                MarcaID = id.Value;
                Marca marca = MarcaData.Marci
                .Where(i => i.ID == id.Value).Single();
                MarcaData.Marci = (IEnumerable<Marca>)marca.Servicii;
            }

        }
    }
}
