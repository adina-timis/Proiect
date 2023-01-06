using Proiect.Migrations;

namespace Proiect.Models
{
    public class ServiciuData
    {
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<CategorieServiciu> CategoriiServicii { get; set; }

    }
}
