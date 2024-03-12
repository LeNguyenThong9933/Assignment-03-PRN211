using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Repository;
namespace eStore
{
    public class MemberController : Controller
    {
        IMemberRepository _memberRepository;
        public MemberController()
        {
            _memberRepository = new MemberRepository();
        }
        // GET: MemberController
        public ActionResult Index(string key="")
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
                if(key!=null && key != "")
                {
                    var members1 = _memberRepository.GetAll().Where(x=> x.ToString().ToLower().Contains(key.ToLower()));
                    return View(members1);
                }
                var members = _memberRepository.GetAll();
                return View(members);
            }
            int userID= Convert.ToInt32(id);
            var member = _memberRepository.GetAll().Where(x=> x.MemberId==userID);
            return View(member);
        }
        public string checkRole()
        {
            if (HttpContext == null || HttpContext.Session == null) return "";
            string id = HttpContext.Session.GetString("id");
            if (id == null) return "";
            if (id.Equals("admin")) return "admin";
            return "";
        }
        // GET: MemberController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var member = _memberRepository.Get(id.Value);
            if (member == null) return NotFound();
            return View(member);
        }

        // GET: MemberController/Create
        public ActionResult Create()
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Create";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // POST: MemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Member member)
        {
            if (!checkRole().Equals("admin"))
            {
                TempData["Message"] = "You don't have right to do Create";
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _memberRepository.Insert(member);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(member);
            }
        }

        // GET: MemberController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var member = _memberRepository.Get(id.Value);
            if (member == null) return NotFound();
            return View(member);
        }

        // POST: MemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Member member)
        {
            try
            {
                if (id != member.MemberId) return NotFound();
                //if(ModelState.IsValid) 
                _memberRepository.Update(member);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // GET: MemberController/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null) return NotFound();
                Member member = _memberRepository.Get(id.Value);
                if (member == null) return NotFound();
                return View(member);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        // POST: MemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _memberRepository.Delete(id);
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
