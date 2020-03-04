using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VidlyModified.Models;

namespace VidlyModified.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MemberShipTypeId { get; set; }
        public MemberShipTypeDto MemberShipType { get; set; }

        //  [Min18YearsIfMember]
        public DateTime? BirthDay { get; set; }
    }
}