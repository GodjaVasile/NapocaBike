using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NapocaBike.Data;
using NapocaBike.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace NapocaBike.Areas.Identity.Pages.Account
{
    [Authorize]
    public class CompleteProfileModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly NapocaBikeContext _context;

        public CompleteProfileModel(
            UserManager<IdentityUser> userManager,
            NapocaBikeContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Member = await _context.Member.FirstOrDefaultAsync(m => m.Email == user.Email);

            if (Member == null)
            {
                return NotFound($"Unable to load member with email '{user.Email}'.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Member existingMember = await _context.Member.FirstOrDefaultAsync(m => m.Email == user.Email);
            if (existingMember != null)
            {
                existingMember.FirstName = Member.FirstName;
                existingMember.LastName = Member.LastName;
                existingMember.Adress = Member.Adress;
                existingMember.Phone = Member.Phone;

                _context.Attach(existingMember).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
