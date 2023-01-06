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
    public IndexModel(Proiect.Data.ProiectContext context) 
    {
     _context = context;
     }
public IList<Serviciu> Serviciu { get; set; }
public ServiciuData ServiciuD { get; set; }
public int ServiciuID { get; set; }
public int CategorieID { get; set; }
public async Task OnGetAsync(int? id, int? categorieID)
{
        ServiciuD = new ServiciuData
        {
            Servicii = await _context.Serviciu
        .Include(b => b.Marca)
        .Include(b => b.CategoriiServicii)
        .ThenInclude(b => b.Categorie)
        .AsNoTracking()
        .OrderBy(b => b.Tip)
        .ToListAsync()
        };
        if (id != null)
    {
        ServiciuID = id.Value;
        Serviciu serviciu = ServiciuD.Servicii
        .Where(i => i.ID == id.Value).Single();
        ServiciuD.Categorii = serviciu.CategoriiServicii.Select(s => s.Categorie);
    }
}
}

