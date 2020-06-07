using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorJournalPage.Models;

namespace RazorJournalPage.Data
{
    public class RazorJournalPageContext : DbContext
    {
        public RazorJournalPageContext (DbContextOptions<RazorJournalPageContext> options)
            : base(options)
        {
        }

        public DbSet<RazorJournalPage.Models.Journal> Journal { get; set; }
    }
}
