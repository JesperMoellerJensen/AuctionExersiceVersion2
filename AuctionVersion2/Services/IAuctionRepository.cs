using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Entities;

namespace AuctionVersion2.Services
{
    public interface IAuctionRepository
    {
        List<AuctionItem> GetAllAuctionItems();
        AuctionItem GetAuctionItem(int itemNumber);
        string ProvideBid(int itemNumber, int bidPrice, string bidCustomName, string bidCustomPhone);

        bool Save();
    }
}
