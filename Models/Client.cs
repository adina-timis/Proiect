using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        
        public ICollection<Programare>? Programari { get; set; }

    }
}
