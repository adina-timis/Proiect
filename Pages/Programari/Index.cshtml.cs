using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                .Include(p => p.Serviciu)
                .ThenInclude(p => p.Personal)
                .Include(b => b.Client)
                .ToListAsync();
            }
        }
    }
}
