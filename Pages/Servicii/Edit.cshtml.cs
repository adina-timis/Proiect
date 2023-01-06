using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Servicii
{
    public class EditModel : CategoriiServiciiPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;
        private Serviciu serviciuToUpdate;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            Serviciu = await _context.Serviciu
 .Include(b => b.Marca)
 .Include(b => b.Personal)
 .Include(b => b.CategoriiServicii).ThenInclude(b => b.Categorie)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            var serviciu =  await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Serviciu);

            var personalList = _context.Personal.Select(x => new
            {
                x.ID,
                FulName = x.Nume + " " + x.Prenume
            });
            
            ViewData["MarcaID"] = new SelectList(_context.Set<Marca>(), "ID", "NumeMarca");
            return Page();
            ViewData["PersonalID"] = new SelectList(_context.Set<Personal>(), "ID", "Personal");
        }

        
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategorii )
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var bookToUpdate = await _context.Serviciu
            .Include(i => i.Marca)
            .Include(i => i.Personal)
            .Include(i => i.CategoriiServicii)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (serviciuToUpdate == null)
            {
                return NotFound();
            }
           
            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Tip, i => i.Personal,
            i => i.Pret, i => i.DataProgramarii, i => i.MarcaID))
            {
                UpdateCategoriiServicii(_context, selectedCategorii, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateCategoriiServicii(_context, selectedCategorii, serviciuToUpdate);
            PopulateAssignedCategoryData(_context, serviciuToUpdate);
            return Page();
        }
    }
}

