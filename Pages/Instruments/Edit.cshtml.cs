using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Inchiriere_Instrumente.Pages.Instruments
{
    [Authorize(Roles = "Admin")]
    public class EditModel : InstrumentCategoriesPageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public EditModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instrument Instrument { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Instrument == null)
            {
                return NotFound();
            }

            Instrument = await _context.Instrument
                .Include(b => b.Owner)
                .Include(b => b.InstrumentCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Instrument == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Instrument);
            Instrument = Instrument;
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "ID", "OwnerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrumentToUpdate = await _context.Instrument
                .Include(i => i.Owner)
                .Include(i => i.InstrumentCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if(instrumentToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Instrument>(
                instrumentToUpdate,
                "Instrument",
                i => i.Name, i => i.Price,
                i => i.PublishingDate, i => i.Owner))
            {
                UpdateInstrumentCategories(_context, selectedCategories, instrumentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateInstrumentCategories(_context, selectedCategories, instrumentToUpdate);
            PopulateAssignedCategoryData(_context, instrumentToUpdate);
            return Page();
        }

    }
}
