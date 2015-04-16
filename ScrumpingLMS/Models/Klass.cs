using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScrumpingLMS.Models
{
    public class Klass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
 //       public DateTime EndDate { get; set; }

        public int NumberOfDays { get; set; }

    }
}