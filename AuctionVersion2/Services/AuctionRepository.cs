using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Entities;
using AuctionVersion2.Model;

namespace AuctionVersion2.Services
{
    public class AuctionRepository : IAuctionRepository
    {
        private AuctionContext _context;

        public AuctionRepository(AuctionContext context)
        {
            _context = context;
        }

        public List<AuctionItem> GetAllAuctionItems()
        {
            return _context.AuctionItems.ToList();
        }

        public AuctionItem GetAuctionItem(int itemNumber)
        {
            return _context.AuctionItems.FirstOrDefault(a => a.ItemNumber == itemNumber);
        }

        public void ApplyBid(Bid bid)
        {
            var auctionItem = _context.AuctionItems.FirstOrDefault(a => a.ItemNumber == bid.ItemNumber);

            auctionItem.BidCustomName = bid.BidCustomName;
            auctionItem.BidCustomPhone = bid.BidCustomPhone;
            auctionItem.BidPrice = bid.BidPrice;
            auctionItem.BudTimeStamp = DateTime.Now;

        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
