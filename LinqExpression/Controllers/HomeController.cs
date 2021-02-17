using LinqExpression.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace LinqExpression.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult Test([FromBody]List<SorguParametre> sorgu)
        {

            var testdata = new List<Ownr> {
                new Ownr{Name = "abc", Qty = 2},
                new Ownr{Name = "abcd", Qty = 11},
                new Ownr{Name = "xyz", Qty = 40},
                new Ownr{Name = "ok", Qty = 5},
            };

            Expression<Func<Ownr, bool>> func=null;

            foreach (var item in sorgu)
            {
                func = Extentions.strToFunc<Ownr>(item.Key, item.Query, item.Value,func);
            }

            var result = testdata.Where(func.ExpressionToFunc()).ToList();

            return View(result);
        }
        public class Ownr
        {
            public string Name { get; set; }
            public int Qty { get; set; }
        }




    }
}
