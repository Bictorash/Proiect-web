using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;

namespace Inchiriere_Instrumente.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public IndexModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }
    }
}
