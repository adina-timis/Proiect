using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Personal
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }

        [Display(Name = "Nume")]
        public string? FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
