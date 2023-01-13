using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Personalul
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DeleteModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Personal Personal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Personalul == null)
            {
                return NotFound();
            }

            var personal = await _context.Personalul.FirstOrDefaultAsync(m => m.ID == id);

            if (personal == null)
            {
                return NotFound();
            }
            else 
            {
                Personal = personal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Personalul == null)
            {
                return NotFound();
            }
            var personal = await _context.Personalul.FindAsync(id);

            if (personal != null)
            {
                Personal = personal;
                _context.Personalul.Remove(Personal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
