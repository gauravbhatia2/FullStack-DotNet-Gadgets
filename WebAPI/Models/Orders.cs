using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public String OrderNo { get; set; }
        public int CustomerID { get; set; }
        public String PMethod { get; set; }
        public String GTotal { get; set; }
    }
}