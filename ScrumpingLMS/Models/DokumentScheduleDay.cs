using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScrumpingLMS.Models
{
    public class DokumentScheduleDay
    {   
        [Key]
        public int Id { get; set; }

        //Foreign Key DokumentId
        public int DokumentId { get; set; }

        [ForeignKey("DokumentId")]
        public virtual Dokument Dokument { get; set; }

        //Foreign Key ScheduleDayId
        public int ScheduleDayId { get; set; }

        [ForeignKey("ScheduleDayId")]
        public virtual ScheduleDay ScheduleDay { get; set; }
    }
}