using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace blogsa.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Get(string name)
        {
            var model = DataService.Instance.Pages.FirstOrDefault(a => a.Name.Equals(name));
            var result = CommonMark.CommonMarkConverter.Convert("**Hello world!**");
            model.Content = result;
            return View(model);
        }
    }
}
