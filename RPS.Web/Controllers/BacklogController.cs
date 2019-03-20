using RPS.Core.Models;
using RPS.Core.Models.Enums;
using RPS.Data;
using RPS.Web.Models.ViewModels;
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

        private readonly IRpsPtItemsRepository rpsItemsRepo;
        private readonly IRpsPtUserRepository rpsUserRepo;

        public BacklogController(IRpsPtItemsRepository rpsItemsData, IRpsPtUserRepository rpsUserData)
        {
            this.rpsItemsRepo = rpsItemsData;
            this.rpsUserRepo = rpsUserData;
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
                    items = rpsItemsRepo.GetOpenItems();
                    break;
                case PresetEnum.Closed:
                    items = rpsItemsRepo.GetClosedItems();
                    break;
                default:
                    items = rpsItemsRepo.GetOpenItems();
                    break;
            }
            return View(items);
        }

        [Route("{id:int}/Details")]
        public ActionResult Details(int id)
        {
            var item = rpsItemsRepo.GetItemById(id);
            var users = rpsUserRepo.GetAll();

            ViewBag.screen = DetailScreenEnum.Details;
            ViewBag.users = users;

            return View("Details", item);
        }

        // POST: Backlog/Detail/5
        [HttpPost]
        [Route("{id:int}/Details")]
        public ActionResult Details(int id, PtItemDetailsVm vm)
        {
            var item = rpsItemsRepo.GetItemById(id);
            var users = rpsUserRepo.GetAll();
            ViewBag.screen = DetailScreenEnum.Details;
            ViewBag.users = users;

            try
            {

                // TODO: Add update logic here
                var updatedItem = rpsItemsRepo.UpdateItem(vm.ToPtUpdateItem());

                return View("Details", updatedItem);
            }
            catch
            {
                return View("Details", item);
            }
        }

        [Route("{id:int}/Tasks")]
        public ActionResult Tasks(int id)
        {
            var item = rpsItemsRepo.GetItemById(id);
            ViewBag.screen = DetailScreenEnum.Tasks;


            return View("Details", item);
        }

        [Route("{id:int}/Chitchat")]
        public ActionResult Chitchat(int id)
        {
            var item = rpsItemsRepo.GetItemById(id);
            ViewBag.screen = DetailScreenEnum.Chitchat;

            
            return View("Details", item);
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

                    rpsItemsRepo.AddNewItem(newItem);

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