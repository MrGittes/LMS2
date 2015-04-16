using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrumpingLMS.Models
{
    public class ScheduleDay
    {
        public int Id { get; set; }

        [DisplayName("Dagnummer")]
        public int DayNumber { get; set; }

        [DisplayName("Datum")]
        public DateTime WorkingDate { get; set; }

        //Foreign Key KlassId
        public int KlassId { get; set; }

        [ForeignKey("KlassId")]
        public virtual Klass Klass { get; set; }

        [DisplayName("Dagsschema")]
        [AllowHtmlAttribute]
        public string Details { get; set; }
    }
}