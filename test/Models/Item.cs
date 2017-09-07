using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AuctionEndDate { get; set; }
        public IList<Bid> Bids { get; private set; }
        public Item()
        {
            Bids = new List<Bid>();
        }

        public void AddBid(Member memberParam, decimal amountParam)
        {
            if (Bids.Count() == 0 || amountParam > Bids.Max(e => e.BidAmount))
            {
                Bids.Add(new Bid()
                {
                    BidAmount = amountParam,
                    DataPlaced = DateTime.Now,
                    Member = memberParam
                });
            }
            else
            {
                throw new InvalidOperationException("Bid amount too low");
            }
        }
    }
}