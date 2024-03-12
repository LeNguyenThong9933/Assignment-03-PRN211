using eStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DataAccess.Models;
using DataAccess.Repository;
namespace eStore.Controllers
{
    public class HomeController : Controller
    {
        IMemberRepository memberRepository;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            memberRepository = new MemberRepository();
        }
        public (string, string) GetAdminAccount()
        {
            IConfiguration config = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", true, true)
                                    .Build();
            String email = config["admin:email"];
            String password = config["admin:pass"];
            return (email, password);
        }
        public string GetUserAccount(Account account)
        {
            var member = memberRepository.GetAll().Where(x=> x.Email.Equals(account.Email) && x.Password.Equals(account.Pass)).FirstOrDefault();
            if (member != null) return member.MemberId.ToString();
            return "";
        }
        public string checkLogin(Account account) {
            (string, string) admin= GetAdminAccount();
            if(admin.Item1.Equals(account.Email) && admin.Item2.Equals(account.Pass)) return "admin";
            string id= GetUserAccount(account);
            if(id!=null) return id; 
            return "";
        }
       

        public IActionResult Index()
        {
            string id = HttpContext.Session.GetString("id");
            ViewBag.Id = id;    
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public ActionResult Verify(Account account)
        {
            string id = checkLogin(account);
            if (id!=null) {
                HttpContext.Session.SetString("id", id);
                ViewBag.Id = id;
                return View("Index");
             }
            else return View("error");
        }
        public ActionResult Logout()
        {
                HttpContext.Session.SetString("id", "");
                return View("Index");
        }
    }
}