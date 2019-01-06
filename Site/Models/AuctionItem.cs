using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class AuctionItem
    {
        public int ItemNumber { get; set; }

        public string ItemDescription { get; set; }
        public long RatingPrice { get; set; }
        public long BidPrice { get; set; }

        [Required]
        [MinLength(4)]
        public string BidCustomName { get; set; }

        [Required]
        [Phone]
        [StringLength(8, MinimumLength = 8)]
        public string BidCustomPhone { get; set; }
        public DateTime BudTimeStamp { get; set; }
    }
}
