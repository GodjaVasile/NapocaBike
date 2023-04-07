using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NapocaBike.Data;
using NapocaBike.Models;

namespace NapocaBike.Pages.BikeRentals
{
    public class EditModel : PageModel
    {
        private readonly NapocaBike.Data.NapocaBikeContext _context;

        public EditModel(NapocaBike.Data.NapocaBikeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BikeRental BikeRental { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BikeRental == null)
            {
                return NotFound();
            }

            var bikerental =  await _context.BikeRental.FirstOrDefaultAsync(m => m.ID == id);
            if (bikerental == null)
            {
                return NotFound();
            }
            BikeRental = bikerental;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BikeRental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeRentalExists(BikeRental.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BikeRentalExists(int id)
        {
          return (_context.BikeRental?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
