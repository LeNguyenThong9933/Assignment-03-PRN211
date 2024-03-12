using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Repository;
namespace eStore.Controllers
{
    public class OderDetailController : Controller
    {
        IOrderDetailRepository _repository;
        OrderDetailDAO OrderDetailDAO = new OrderDetailDAO();  
        public OderDetailController()
        {
            _repository= new OrderDetailRepository();
        }
        // GET: OderDetailController
        public ActionResult Index(string key = "")
        {
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                TempData.Remove("Message");
            }
            if (key != null && key != "")
            {
                var orderDetail = _repository.GetAll().Where(x => x.ToString().ToLower().Contains(key.ToLower()));
                return View(orderDetail);
            }
            var orderDetails= _repository.GetAll();
            return View(orderDetails);
        }
        public ActionResult IndexById(int id)
        {
            var orderDetails = _repository.GetAll().Where(x=> x.OrderId==id);
            return View(orderDetails);
        }
        public string checkRole()
        {
            if (HttpContext == null || HttpContext.Session == null) return "";
            string id = HttpContext.Session.GetString("id");
            if (id == null) return "";
            if (id.Equals("admin")) return "admin";
            return "";
        }
        // GET: OderDetailController/Details/5
        public ActionResult Details(int OrderID, int ProductID)
        {
            var orderDetail = _repository.GetAll().Where(x => x.OrderId == OrderID && x.ProductId == ProductID).FirstOrDefault();
            return View(orderDetail);
        }

        // GET: OderDetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OderDetailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            try
            {
                OrderDetailDAO.Insert(orderDetail);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(orderDetail);
            }
        }

        // GET: OderDetailController/Edit/5
        public ActionResult Edit(int? OrderID, int? ProductID)
        {
            if (OrderID == null || ProductID== null) return NotFound();
            var orderDetail = _repository.Get(OrderID.Value, ProductID.Value);
            if (orderDetail == null) return NotFound();
            return View(orderDetail);
        }

        // POST: OderDetailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int OrderID, int ProductID, OrderDetail orderDetail)
        {
            try
            {
                if (ProductID != orderDetail.ProductId || OrderID!= orderDetail.OrderId) return NotFound();
                //if(ModelState.IsValid) 
                _repository.Update(orderDetail);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: OderDetailController/Delete/5
        public ActionResult Delete(int? OrderID, int? ProductID)
        {
            try
            {
                if (OrderID == null || ProductID==null) return NotFound();
                OrderDetail orderDetail = _repository.Get(OrderID.Value, ProductID.Value);
                if (orderDetail == null) return NotFound();
                return View(orderDetail);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // POST: OderDetailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? OrderID, int? ProductID, OrderDetail orderDetail)
        {
            try
            {
                _repository.Delete(orderDetail.OrderId, orderDetail.ProductId);
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
