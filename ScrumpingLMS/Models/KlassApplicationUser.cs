using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScrumpingLMS.Models
{
    public class KlassApplicationUser
    {
        public int Id { get; set; }

        //Foreign Key ApplicationUserId
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        //Foreign Key KlassId
        public int KlassId { get; set; }

        [ForeignKey("KlassId")]
        public virtual Klass Klass { get; set; }

        public KlassApplicationUser()
        {
        }

        public KlassApplicationUser(int _KlassId, string _ApplicationUserId)
        {
            KlassId = _KlassId;
            ApplicationUserId = _ApplicationUserId;
        }

    }
}