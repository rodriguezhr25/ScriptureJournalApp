﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RazorJournalPage.Models
{
    public class Journal
    {
        public int ID { get; set; }
        [Required, Display(Name = "Book Name"), StringLength(60, MinimumLength = 3)]
        public string BookName { get; set; }

        [Display(Name = "Date Added"), DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only positive number"), Column(TypeName = "int")]
        public int Chapter { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only positive number"), Column(TypeName = "int")]
        public int Verse { get; set; }

        [Required, MaxLength(300)]
        public string Note { get; set; }
    }
}
