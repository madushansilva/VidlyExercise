using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyModified.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        [Display (Name="Membership")]
        public MemberShipType MemberShipType { get; set; }
        public byte MemberShipTypeId { get; set; }
        [Display(Name="Date Of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDay { get; set; }
    }
}