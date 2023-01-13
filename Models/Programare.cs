using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
