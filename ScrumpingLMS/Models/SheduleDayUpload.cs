using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScrumpingLMS.Models
{
    public class ScheduleDayUpload
    {
        public int Id { get; set; }

        public int DayNumber { get; set; }

        //Foreign Key KlassId
        public int KlassId { get; set; }

        [ForeignKey("KlassId")]
        public virtual Klass Klass { get; set; }

        public string LinkToDokument { get; set; }

    }
}