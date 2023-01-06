using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;
namespace Proiect.Models
{
    public class CategoriiServiciiPageModel : PageModel
    {
        public List<AlegereCategorie> AlegereCategorieList;
        public void PopulateAlegereCategorie(ProiectContext context, Serviciu serviciu)
        {
            var allCategories = context.Categorie;
            var serviciuCategorii = new HashSet<int>(
            serviciu.CategoriiServicii.Select(c => c.CategorieID)); //
            AlegereCategorieList = new List<AlegereCategorie>();
            foreach (var cat in allCategories)
            {
                AlegereCategorieList.Add(new AlegereCategorie
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Alege = serviciuCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiServicii(ProiectContext context,
        string[] selectedCategories, Serviciu serviciuToUpdate)
        {
            if (selectedCategories == null)
            {
                serviciuToUpdate.CategoriiServicii = new List<CategorieServiciu>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var serviciuCategorii = new HashSet<int>
            (serviciuToUpdate.CategoriiServicii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!serviciuCategorii.Contains(cat.ID))
                    {
                        serviciuToUpdate.CategoriiServicii.Add(
                        new CategorieServiciu
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (serviciuCategorii.Contains(cat.ID))
                    {
                        CategorieServiciu courseToRemove
                        = serviciuToUpdate
                        .CategoriiServicii
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }

        }
    }
}
