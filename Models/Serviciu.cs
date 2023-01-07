using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class Serviciu
    {
        public int ID { get; set; }
        [Display(Name = "Tip serviciu")]
        public string Tip { get; set; }
       
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data programarii")]
        public DateTime DataProgramarii { get; set; }

        public int? MarcaID { get; set; }
        public Marca? Marca { get; set; }

       public int? PersonalID { get; set; }
        public Personal? Personal { get; set; }
        public ICollection<CategorieServiciu>? CategoriiServicii { get; set; }
        
    }
}
