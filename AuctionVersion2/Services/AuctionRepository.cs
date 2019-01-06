using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Entities;

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

        public string ProvideBid(int itemNumber, int bidPrice, string bidCustomName, string bidCustomPhone)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
