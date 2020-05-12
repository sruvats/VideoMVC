using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video.Models;

namespace video.ViewModels
{
    public class CustomerViewModel
    {
        public  IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer Customer { get; set; }
    }

   
}