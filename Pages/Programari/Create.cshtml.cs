using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var serviciuList = _context.Serviciu
 .Include(b => b.Personal)
 .Select(x => new
 {
     x.ID,
     ServiciuFullName = x.Tip + " - " + x.Personal.Nume + " " +
x.Personal.Prenume
 });
            ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
        ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
