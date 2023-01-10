using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;

namespace Inchiriere_Instrumente.Pages.Instruments
{
    public class DetailsModel : PageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public DetailsModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

      public Instrument Instrument { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instrument == null)
            {
                return NotFound();
            }

            var instrument = await _context.Instrument.FirstOrDefaultAsync(m => m.ID == id);
            if (instrument == null)
            {
                return NotFound();
            }
            else 
            {
                Instrument = instrument;
            }
            return Page();
        }
    }
}
