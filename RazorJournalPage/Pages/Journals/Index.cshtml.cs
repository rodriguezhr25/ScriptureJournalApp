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
    public class IndexModel : PageModel
    {
        private readonly RazorJournalPage.Data.RazorJournalPageContext _context;

        public IndexModel(RazorJournalPage.Data.RazorJournalPageContext context)
        {
            _context = context;
        }

        public IList<Journal> Journal { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchBook { get; set; }
       
        [BindProperty(SupportsGet = true)]
        public string SearchNote { get; set; }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string BookFilter { get; set; }
        public string NoteFilter { get; set; }
        public async Task OnGetAsync(string sortOrder , string bookFilter, string noteFilter, string searchBook, string searchNote)
        {
           
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchBook == null)
            {
              
                searchBook = bookFilter;
            }
            if (searchNote == null)
            {

                searchNote = noteFilter;
            }
            BookFilter = searchBook;
            NoteFilter = searchNote;
            IQueryable<Journal> scriptureNotes = from s in _context.Journal
                                             select s;

            if (!string.IsNullOrEmpty(searchBook))
            {
                scriptureNotes = scriptureNotes.Where(s => s.BookName.Contains(searchBook));
            }
            if (!string.IsNullOrEmpty(searchNote))
            {
                scriptureNotes = scriptureNotes.Where(s => s.Note.Contains(searchNote));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    scriptureNotes = scriptureNotes.OrderByDescending(s => s.BookName);
                    break;
                case "Date":
                    scriptureNotes = scriptureNotes.OrderBy(s => s.DateAdded);
                    break;
                case "date_desc":
                    scriptureNotes = scriptureNotes.OrderByDescending(s => s.DateAdded);
                    break;
                default:
                    scriptureNotes = scriptureNotes.OrderBy(s => s.BookName);
                    break;
            }
          
            Journal = await scriptureNotes.AsNoTracking().ToListAsync();
        }
    }
}