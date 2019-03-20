using RPS.Core.Models;
using RPS.Core.Models.Enums;
using RPS.Data;
using RPS.Web.Models.Data;
using RPS.Web.Models.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RPS.Web.Controllers
{
    [RoutePrefix("Backlog")]
    public class BacklogController : Controller
    {
        private const int CURRENT_USER_ID = 21; //Fake user id for demo

        private readonly IRpsPtItemsRepository rpsData;

        public BacklogController(IRpsPtItemsRepository rpsData)
        {
            this.rpsData = rpsData;
        }

        // GET: Backlog
        public ActionResult Index()
        {
            return RedirectToAction("Items", new RouteValueDictionary(
                new { controller = "Backlog", action = "Main", preset = "Open" }));

        }

        [Route("Items/{preset}")]
        public ActionResult Items(PresetEnum preset)
        {
            IEnumerable<PtItem> items = null;
            switch (preset)
            {
                case PresetEnum.Open:
                    items = rpsData.GetOpenItems();
                    break;
                case PresetEnum.Closed:
                    items = rpsData.GetClosedItems();
                    break;
                default:
                    items = rpsData.GetOpenItems();
                    break;
            }
            return View(items);
        }

        [Route("Detail/{id:int}/{screen?}")]
        public ActionResult Detail(int id, DetailScreenEnum? screen)
        {
            if (!screen.HasValue)
            {
                return RedirectToAction("Detail", new RouteValueDictionary(
                    new { controller = "Backlog", action = "Detail", id, screen = DetailScreenEnum.Details }));
            }

            ViewBag.screen = screen;

            var item = rpsData.GetItemById(id);
            return View(item);
        }

        // GET: Backlog/Create
        public ActionResult Create()
        {
            var vm = new PtNewItemVm();
            return View(vm);
        }

        // POST: Backlog/Create
        [HttpPost]
        public ActionResult Create(PtNewItemVm vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                
                    var newItem = vm.ToPtNewItem();
                    newItem.UserId = CURRENT_USER_ID;

                    rpsData.AddNewItem(newItem);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(vm);
                }


            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Backlog/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Backlog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}