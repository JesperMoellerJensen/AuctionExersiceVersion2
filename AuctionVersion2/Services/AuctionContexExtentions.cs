using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Entities;

namespace AuctionVersion2.Services
{
    public static class AuctionContexExtentions
    {
        public static void EnsureSeedDataForContext(this AuctionContext contex)
        {
            if (contex.AuctionItems.Any())
            {
                return;
            }

            var auctionItems = new List<AuctionItem>
            {
                new AuctionItem
                {
                    ItemDescription = "Nokia 3310, virker stadig",
                    RatingPrice = 350
                },
                new AuctionItem
                {
                    ItemDescription = "Blå stol",
                    RatingPrice = 500
                },
                new AuctionItem
                {
                    ItemDescription = "Bord",
                    RatingPrice = 2500
                },
                new AuctionItem
                {
                    ItemDescription = "Lampe grå",
                    RatingPrice = 670
                },
                new AuctionItem
                {
                    ItemDescription = "Statue af Jesus",
                    RatingPrice = 5000
                }
            };

            contex.AddRange(auctionItems);
            contex.SaveChanges();
        }
    }
}

