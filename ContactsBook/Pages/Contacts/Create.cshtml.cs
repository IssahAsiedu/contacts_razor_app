using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactsBook.Database;
using ContactsBook.Models;

namespace ContactsBook.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly ContactsBook.Database.ContactDbContext _context;

        public CreateModel(ContactsBook.Database.ContactDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Contacts == null || Contact == null)
            {
                return Page();
            }

            Contact.DateAdded = DateTimeOffset.UtcNow;

            _context.Contacts.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
