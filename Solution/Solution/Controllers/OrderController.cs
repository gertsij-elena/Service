using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Solution.Models;
using PagedList;

namespace Solution.Controllers
{
   
    public class OrderController : Controller
    {


        // GET: Order

        DataContext db = new DataContext();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            IEnumerable<Order> listOrder = db.Orders.ToList();
            return View(listOrder.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult OrderList()
        {
            return View();
        }

        public JsonResult GetOrders()
        {
            var result = db.Orders.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Order/Create
        [HttpPost]
        public JsonResult Create(Order order)
        {
            try
            {
                order.DateCreate = DateTime.Now;
                order.DateAdd = DateTime.Now.AddMonths(2);
                order.Old = false;
                db.Orders.Add(order);
                db.SaveChanges();
                return Json(new { status = "Ваш заказ успешно добавлен." });
                //RedirectToAction("OrderList", "Order", new Solution.Models.Order { OrderId = order.OrderId });
               
            }
            catch
            {
                return Json(new { status = "Произошла ошибка!Повторите заказ." });
                
            }
          
        }
        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
