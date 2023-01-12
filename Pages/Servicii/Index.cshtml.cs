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
        public string TipSort { get; set; }
        public string PersonalSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categorieID, string sortOrder,
            string searchString)
        {
            ServiciuD = new ServiciuData();
            TipSort = String.IsNullOrEmpty(sortOrder) ? "tip_desc" : "";
            PersonalSort = String.IsNullOrEmpty(sortOrder) ? "personal_desc" : "";

            CurrentFilter = searchString;

            ServiciuD.Servicii = await _context.Serviciu
                .Include(i => i.Personal)
                .Include(i => i.Marca)
                .Include(i => i.CategoriiServicii)
                .ThenInclude(i => i.Categorie)
                .AsNoTracking()
                .OrderBy(i => i.Tip)
                .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Personal.Nume.Contains(searchString)

               || s.Personal.Prenume.Contains(searchString)
               || s.Tip.Contains(searchString));
            }

                if (id != null)
                {
                    ServiciuID = id.Value;
                    Serviciu serviciu = ServiciuD.Servicii
                    .Where(i => i.ID == id.Value).Single();
                    ServiciuD.Categorii = serviciu.CategoriiServicii.Select(s => s.Categorie);
                }
                switch (sortOrder)
                {
                    case "tip_desc":
                        ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                       s.Tip);
                        break;
                    case "personal_desc":
                        ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                       s.Personal.FullName);
                        break;

                }
            }
        }
    }


