using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NapocaBike.Data;
using NapocaBike.Models;

namespace NapocaBike.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly NapocaBike.Data.NapocaBikeContext _context;

        public IndexModel(NapocaBike.Data.NapocaBikeContext context)
        {
            _context = context;
        }

        public IList<Location> Location { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Location != null)
            {
                Location = await _context.Location.ToListAsync();
            }
        }
    }
}
