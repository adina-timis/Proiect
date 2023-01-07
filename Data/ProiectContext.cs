using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect.Models;

namespace Proiect.Data
{
    public class ProiectContext : DbContext
    {
        public ProiectContext (DbContextOptions<ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Proiect.Models.Marca> Marca { get; set; }

        public DbSet<Proiect.Models.Categorie> Categorie { get; set; }
        public IEnumerable<object> Personal { get; internal set; }
    }
}
