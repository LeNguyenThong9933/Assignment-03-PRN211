using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Repository;
namespace eStore.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderrRepository;
        public OrderController()
        {
            _orderrRepository = new OrderRepository();
        }
        // GET: OrderController
        public ActionResult Index(string key= "")
        {
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                TempData.Remove("Message");
            }
            string id = HttpContext.Session.GetString("id");
            ViewBag.Id = id;
            if (id == null || id.Equals(""))
                return View();
            else if (id.Equals("admin"))
            {
                if (key != null && key != "")
                {
                    var order = _orderrRepository.GetAll().Where(x => x.ToString().ToLower().Contains(key.ToLower()));
                    return View(order);
                }
                var orderrs = _orderrRepository.GetAll();
                return View(orderrs);
            }
            int userID = Convert.ToInt32(id);
            var orderr = _orderrRepository.GetAll().Where(x => x.MemberId == userID);
            if (key != null && key != "")
            {
                var order = orderr.Where(x => x.ToString().ToLower().Contains(key.ToLower()));
                return View(order);
            }                 
            return View(orderr);
        }
        public string checkRole()
        {
            if (HttpContext == null || HttpContext.Session == null) return "";
            string id = HttpContext.Session.GetString("id");
            if (id != null) return id.ToString();
            if (id.Equals("admin")) return "admin";
            return "";
        }
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var order = _orderrRepository.GetAll().Where(x=> x.OrderId==id).FirstOrDefault();
            return View(order);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {

            string id = checkRole();
            ViewBag.Id = id;
            if (id == null || id.Equals(""))
            {
                TempData["Message"] = "You don't have right to do Create";
                return RedirectToAction(nameof(Index));
            }
           
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order orderr)
        {
            try
            {
                _orderrRepository.Insert(orderr);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(orderr);
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var member = _orderrRepository.Get(id.Value);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order orderr)
        {
            try
            {
                if (id != orderr.OrderId) return NotFound();
                //if(ModelState.IsValid) 
                _orderrRepository.Update(orderr);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null) return NotFound();
                Order orderr = _orderrRepository.Get(id.Value);
                if (orderr == null) return NotFound();
                return View(orderr);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _orderrRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}
