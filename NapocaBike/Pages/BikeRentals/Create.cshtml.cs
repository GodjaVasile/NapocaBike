using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NapocaBike.Data;
using NapocaBike.Models;

namespace NapocaBike.Pages.BikeRentals
{
    public class CreateModel : PageModel
    {
        private readonly NapocaBike.Data.NapocaBikeContext _context;

        public CreateModel(NapocaBike.Data.NapocaBikeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BikeRental BikeRental { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BikeRental == null || BikeRental == null)
            {
                return Page();
            }

            _context.BikeRental.Add(BikeRental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
