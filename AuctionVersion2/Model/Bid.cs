using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuctionVersion2.Model
{
    public class Bid
    {
        public int ItemNumber { get; set; }
        public long BidPrice { get; set; }
        public string BidCustomName { get; set; }
        public string BidCustomPhone { get; set; }
    }
}
