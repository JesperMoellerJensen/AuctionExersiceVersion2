using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Entities;
using AuctionVersion2.Model;

namespace AuctionVersion2.Services
{
    public interface IAuctionRepository
    {
        List<AuctionItem> GetAllAuctionItems();
        AuctionItem GetAuctionItem(int itemNumber);
        void ApplyBid(Bid bid);
        bool Save();
    }
}
