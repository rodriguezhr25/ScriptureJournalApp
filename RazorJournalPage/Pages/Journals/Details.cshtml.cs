using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorJournalPage.Data;
using RazorJournalPage.Models;

namespace RazorJournalPage.Pages.Journals
{
    public class DetailsModel : PageModel
    {
        private readonly RazorJournalPage.Data.RazorJournalPageContext _context;

        public DetailsModel(RazorJournalPage.Data.RazorJournalPageContext context)
        {
            _context = context;
        }

        public Journal Journal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Journal = await _context.Journal.FirstOrDefaultAsync(m => m.ID == id);

            if (Journal == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
