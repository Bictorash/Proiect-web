using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inchiriere_Instrumente.Models;

namespace Inchiriere_Instrumente.Data
{
    public class Inchiriere_InstrumenteContext : DbContext
    {
        public Inchiriere_InstrumenteContext (DbContextOptions<Inchiriere_InstrumenteContext> options)
            : base(options)
        {
        }

        public DbSet<Inchiriere_Instrumente.Models.Instrument> Instrument { get; set; } = default!;

        public DbSet<Inchiriere_Instrumente.Models.Owner> Owner { get; set; }

        public DbSet<Inchiriere_Instrumente.Models.Category> Category { get; set; }

        public DbSet<Inchiriere_Instrumente.Models.Member> Member { get; set; }

        public DbSet<Inchiriere_Instrumente.Models.Borrowing> Borrowing { get; set; }
    }
}
