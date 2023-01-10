using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;
using System.Net;

namespace Inchiriere_Instrumente.Pages.Instruments
{
    public class IndexModel : PageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public IndexModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

        public IList<Instrument> Instrument { get;set; } = default!;
        public InstrumentData InstrumentD { get; set; }
        public int InstrumentID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            InstrumentD = new InstrumentData();

            InstrumentD.Instruments = await _context.Instrument
            .Include(b => b.Owner)
            .Include(b => b.InstrumentCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                InstrumentID = id.Value;
                Instrument instrument = InstrumentD.Instruments
                .Where(i => i.ID == id.Value).Single();
                InstrumentD.Categories = instrument.InstrumentCategories.Select(s => s.Category);
            }
        }
    }
}
