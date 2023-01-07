using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Servicii
{
    public class IndexModel : PageModel
    {

        private readonly Proiect.Data.ProiectContext _context;
        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get; set; } = default;
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int CategorieID { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ServiciuD = new ServiciuData();
            {
                ServiciuD.Servicii = await _context.Serviciu
            .Include(s => s.Marca)
             .Include(s => s.Personal)
            .Include(s => s.CategoriiServicii)
            .ThenInclude(s => s.Categorie)
            .AsNoTracking()
            .OrderBy(s => s.Tip)
            .ToListAsync();

                if (id != null)
                {
                    ServiciuID = id.Value;
                    Serviciu serviciu = ServiciuD.Servicii
                    .Where(i => i.ID == id.Value).Single();
                    ServiciuD.Categorii = serviciu.CategoriiServicii.Select(s => s.Categorie);
                }
            }
        }
    }
}

