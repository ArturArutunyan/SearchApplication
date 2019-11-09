using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SearchApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISnippetManager _snippetManager;
        public HomeController(ISnippetManager snippetManager)
        {
            _snippetManager = snippetManager;
        }
        public IActionResult Index()
        {           
            return View();
        }

        public async Task<IActionResult> GetDataFromParser([FromForm]string searchQuery, int count = 10)
        {
            var snippets = await _snippetManager.GetSnippetsFromParserAsync(searchQuery, count);
            return View("Index", snippets);
        }

        public async Task<IActionResult> GetDataFromDb(int count = 20)
        {
            var snippets = await _snippetManager.GetSnippetsFromDbAsync(count);
            return View("Index", snippets);
        }
    }
}
