using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ScrumpingLMS.Models
{
    public class SharedFolderApplicationUser
    {
        [Key]
        public int Id { get; set; }


        //Foreign Key SharedFolderId
        public int SharedFolderId { get; set; }

        [ForeignKey("SharedFolderId")]
        public virtual SharedFolder SharedFolder { get; set; }

        //Foreign Key ApplicationUserId
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}