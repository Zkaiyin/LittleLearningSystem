using LittleLearningSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authentication;

namespace LittleLearningSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly LittleLearningContext _context;

        public HomeController(LittleLearningContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            TempData["Email"] = email;

            var student = await _context.Students
                .FirstOrDefaultAsync(s => s.Email == email && s.Spassword == password);

            if (student != null)
            {
                // �n�����\�A���w�V��ҵ{����
                return RedirectToAction("Index", "Course");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            // �`�P�޿�i�H�b�o�̹�{�A�ھڻݭn�i��
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }
    }
}
