using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVersion2.Controllers
{
    [Route("api/auctions")]
    public class AuctionsController : Controller
    {
        private IAuctionRepository _auctionRepository;

        public AuctionsController(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        [HttpGet]
        public IActionResult GetAllAuctionItems()
        {
            var auctionItems = _auctionRepository.GetAllAuctionItems();

            return Ok(auctionItems);
        }

        [HttpGet("{itemNumber}")]
        public IActionResult GetAuctionItem(int itemNumber)
        {
            var auctionItem = _auctionRepository.GetAuctionItem(itemNumber);

            if (auctionItem == null)
            {
                return NotFound();
            }

            return Ok(auctionItem);
        }

    }
}
