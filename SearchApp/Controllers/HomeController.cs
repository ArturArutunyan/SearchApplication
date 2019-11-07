using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SearchApp.Models;
using ServiceParser.SearchEngine;
using ServiceParser.SearchServices.Yandex;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult GetDataFromParser([FromForm]string searchQuery)
        {
            var snippets = _snippetManager.GetTenSnippetsFromParser(searchQuery);
            return View("Index", snippets);
        }

        public IActionResult GetDataFromDb()
        {
            var snippets = _snippetManager.GetTenSnippetsFromDb();
            return View("Index", snippets);
        }
    }
}
