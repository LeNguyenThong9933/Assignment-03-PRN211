using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Repository;
namespace eStore
{
    public class ProductController : Controller
    {
        IProductRepository _repository;
        ICategoryRepository _categoryRepository;
        ProductDAO productDAO = new ProductDAO();
        public ProductController()
        {
            _repository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }

        // GET: ProductController

        public ActionResult Index(string key = "")
        {
            if (TempData.ContainsKey("Message"))
            {
                ViewBag.Message = TempData["Message"].ToString();
                TempData.Remove("Message");
            }
            if (key!=null && key != "" )
            {
                var product = _repository.GetAll().Where(x => x.ToString().ToLower().Contains(key.ToLower()));
                return View(product);
            }
            var products = _repository.GetAll();
            return View(products);
        }
        public string checkRole()
        {
            if (HttpContext == null || HttpContext.Session==null) return "";
            string id= HttpContext.Session.GetString("id");
            if (id == null) return "";
            if (id.Equals("admin")) return "admin";
            return "";
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var product = _repository.Get(id.Value);
            if (product == null) return NotFound();
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Create";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Create";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                 productDAO.Insert(product); 
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(product);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Edit";
                return RedirectToAction(nameof(Index));
            }
            if (id == null) return NotFound();
            var product = _repository.Get(id.Value);
            if(product == null) return NotFound();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Edit";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                product.Category= _categoryRepository.Get(product.CategoryId);
                if (id!= product.ProductId) return NotFound();
                //if(ModelState.IsValid) 
                    _repository.Update(product);
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int? id)
        {

            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Delete";
                return RedirectToAction(nameof(Index));
            }
            try {
                if(id==null) return NotFound();
                Product product= _repository.Get(id.Value);
                if(product==null) return NotFound();
                return View(product);
            }catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Delete";
                return RedirectToAction(nameof(Index));
            }
            try
            {
               _repository.Delete(id);    
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
