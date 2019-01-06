using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site.Helpers;
using Site.Models;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private IApiHelper _apiHelper;

        public HomeController(IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
            _apiHelper.BaseUri = new Uri("http://localhost:61187");
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AuctionItem> auctionItems = _apiHelper.Get<List<AuctionItem>>("api/auctions");
            return View(auctionItems);
        }

        [HttpGet]
        public IActionResult Details(int? itemNumber)
        {
            if (itemNumber == null)
            {
                return Redirect("Index");
            }

            var auctionItem = _apiHelper.Get<AuctionItem>("api/auctions/" + itemNumber);
            return View(auctionItem);
        }

        [HttpGet]
        public IActionResult MyAuctions(string name)
        {
            List<AuctionItem> auctionItems = _apiHelper.Get<List<AuctionItem>>("api/auctions");

            List<AuctionItem> auctionsItemsResult = auctionItems.Where(a => a.BidCustomName == name).ToList();

            return View(auctionsItemsResult);
        }

        [HttpPost]
        public IActionResult Details(AuctionItem item)
        {
            if (item == null)
            {
                return Redirect("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(item);
            }

            Bid bid = new Bid
            {
                ItemNumber = item.ItemNumber,
                BidCustomName = item.BidCustomName,
                BidCustomPhone = item.BidCustomPhone,
                BidPrice = item.BidPrice
            };

            if (_apiHelper.Post(bid, "api/auctions"))
            {
                ViewBag.BidComepleted = true;
            }
            else
            {
                ViewBag.BidComepleted = false;
            }

            return View(item);
        }
    }
}
