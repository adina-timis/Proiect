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
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Personal> Personal { get; set; } = default!;


        public async Task OnGetAsync()
        {
            if (_context.Personalul != null)
            {
                Personal = await _context.Personalul.ToListAsync();
            }
        }
    }
}
