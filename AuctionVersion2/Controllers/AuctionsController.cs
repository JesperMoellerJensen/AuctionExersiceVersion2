using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionVersion2.Model;
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

        [HttpPost]
        public IActionResult ProvideBid([FromBody]Bid bid)
        {

            var auctionItem = _auctionRepository.GetAuctionItem(bid.ItemNumber);

            if (auctionItem == null)
            {
                return NotFound("Vare findes ikke");
            }

            if (auctionItem.BidPrice > bid.BidPrice)
            {
                return BadRequest("Bud for lavt");
            }

            _auctionRepository.ApplyBid(bid);


            if (!_auctionRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request");
            }

            return NoContent();
        }

    }
}
