﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Inchiriere_Instrumente.Data;
using Inchiriere_Instrumente.Models;

namespace Inchiriere_Instrumente.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext _context;

        public CreateModel(Inchiriere_Instrumente.Data.Inchiriere_InstrumenteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstrumentID"] = new SelectList(_context.Instrument, "ID", "ID");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
