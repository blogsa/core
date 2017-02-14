using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace blogsa.Controllers
{
    public class ContentController : Controller
    {
        public IActionResult Page(string name)
        {
            var model = DataService.Instance.Pages.FirstOrDefault(a => a.Name.Equals(name));
            var result = CommonMark.CommonMarkConverter.Convert("**Hello world!**");
            model.Content = result;
            return View(model);
        }

         public IActionResult Post(string name)
        {
            var model = DataService.Instance.Posts.FirstOrDefault(a => a.Name.Equals(name));
            var result = CommonMark.CommonMarkConverter.Convert("**Hello world!**");
            model.Content = result;
            return View(model);
        }
    }
}
