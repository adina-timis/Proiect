using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Servicii
{
    public class CreateModel : CategoriiServiciiPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;
        private IEnumerable personalList;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            /*var personalList = _context.Personal.Select(x => new
            {
                x.ID,
                FullName = x.Nume + " " + x.Prenume
            });*/

            ViewData["MarcaID"] = new SelectList(_context.Marca, "ID", "NumeMarca");
            ViewData["PersonalID"] = new SelectList(personalList, "ID", "FullName");


            var serviciu = new Serviciu();
            serviciu.CategoriiServicii = new List<CategorieServiciu>();
            PopulateAssignedCategoryData(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }
        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newServiciu = new Serviciu();
            if (selectedCategorii != null)
            {
                newServiciu.CategoriiServicii = new List<CategorieServiciu>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new CategorieServiciu
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newServiciu.CategoriiServicii.Add(catToAdd);
                }
            }
            Serviciu.CategoriiServicii = newServiciu.CategoriiServicii;
            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        
    }
} 

