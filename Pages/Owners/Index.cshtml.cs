using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;
using Inchiriere_Instrumente.Models.ViewModels;

namespace Inchiriere_Instrumente.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public IndexModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; } = default!;

        public OwnerIndexData OwnerData { get; set; }
        public int OwnerID { get; set; }
        public int InstrumentID { get; set; }

        public async Task OnGetAsync(int? id, int? instrumentID)
        {
            OwnerData = new OwnerIndexData();
            OwnerData.Owners = await _context.Owner.Include(i => i.Instruments)
                                                   .OrderBy(i => i.OwnerName)
                                                   .ToListAsync();
            if(id != null)
            {
                OwnerID = id.Value;
                Owner owner = OwnerData.Owners
                    .Where(i => i.Id == id.Value).Single();
                OwnerData.Instruments = owner.Instruments;
            }
        }
    }
}
