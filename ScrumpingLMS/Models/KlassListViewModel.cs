using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ScrumpingLMS.Models
{
    public class KlassListViewModel
    {
        public int Id { get; set; }

        [DisplayName("Kursnamn")]
        public string Name { get; set; }

        [DisplayName("Startdatum")]
        public DateTime StartDate { get; set; }

        [DisplayName("Antal dagar")]
        public int NumberOfDays { get; set; }

        [DisplayName("Lärare")]
        public string TeacherName { get; set; }
    }
}