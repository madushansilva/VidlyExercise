using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyModified.Models;

namespace VidlyModified.ViewModel
{
    public class NewCustomerViewModel
    {

        public IEnumerable<MemberShipType> MemberShipType { get; set; }

        public Customer Customer { get; set; }
    }
}