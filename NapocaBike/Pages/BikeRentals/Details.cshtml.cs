﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NapocaBike.Data;
using NapocaBike.Models;

namespace NapocaBike.Pages.BikeRentals
{
    public class DetailsModel : PageModel
    {
        private readonly NapocaBike.Data.NapocaBikeContext _context;

        public DetailsModel(NapocaBike.Data.NapocaBikeContext context)
        {
            _context = context;
        }

      public BikeRental BikeRental { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BikeRental == null)
            {
                return NotFound();
            }

            var bikerental = await _context.BikeRental.FirstOrDefaultAsync(m => m.ID == id);
            if (bikerental == null)
            {
                return NotFound();
            }
            else 
            {
                BikeRental = bikerental;
            }
            return Page();
        }
    }
}
