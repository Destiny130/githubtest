using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Bid
    {
        public Member Member { get; set; }
        public DateTime DataPlaced { get; set; }
        public decimal BidAmount { get; set; }
    }
}