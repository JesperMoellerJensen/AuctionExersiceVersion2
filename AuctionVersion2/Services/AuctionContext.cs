using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionVersion2.Services
{
    public class AuctionContext : DbContext
    {
        public DbSet<AuctionItem> AuctionItems { get; set; }

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
