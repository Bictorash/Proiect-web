using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inchiriere_Instrumente.Pages.Instruments
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : InstrumentCategoriesPageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public CreateModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["OwnerID"] = new SelectList(_context.Set<Owner>(), "ID", "OwnerName");
            var instrument = new Instrument();
            instrument.InstrumentCategories = new List<InstrumentCategory>();
            PopulateAssignedCategoryData(_context, instrument);
            return Page();
        }

        [BindProperty]
        public Instrument Instrument { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newInstrument = Instrument;
            if (selectedCategories != null)
            {
                newInstrument.InstrumentCategories = new List<InstrumentCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new InstrumentCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newInstrument.InstrumentCategories.Add(catToAdd);
                }
            }
            
            _context.Instrument.Add(newInstrument);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newInstrument);
            return Page();
        }
    }
}
