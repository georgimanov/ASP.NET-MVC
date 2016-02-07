namespace Calculator.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private Dictionary<string, double> result;

        public HomeController()
        {
            this.result = new Dictionary<string, double>();
            this.result.Add("Bit",  Math.Pow(2, 40));
            this.result.Add("Kilobit", Math.Pow(2, 30));
            this.result.Add("Megabit", Math.Pow(2, 20));
            this.result.Add("Gigabit", Math.Pow(2, 10));
            this.result.Add("Terabit", Math.Pow(2, 0));
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.ViewBag.Result = this.result;

            return View();
        }

        [HttpPost]
        public ActionResult Index(int quantity, string type)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewBag.Result = this.result;
                return View();
            }

            var dict = new Dictionary<string, double>();
            foreach (var val in GetValue(type))
            {
                dict.Add(val.Key, val.Value * quantity);
            }

            this.ViewBag.Result = dict;

            return View();
        }

        private Dictionary<string, double> GetValue(string type)
        {
            var dict = new Dictionary<string, double>();
            if (type == "B")
            {
                dict.Add("bit", Math.Pow(2, 0));
                dict.Add("Kilobit", 1 / Math.Pow(2, 10));
                dict.Add("Megabit", 1 / Math.Pow(2, 20));
                dict.Add("Gigabit", 1 / Math.Pow(2, 30));
                dict.Add("Terabit", 1 / Math.Pow(2, 40));
            }
            else if (type == "K")
            {
                dict.Add("bit", Math.Pow(2, 10));
                dict.Add("Kilobit", Math.Pow(2, 0));
                dict.Add("Megabit", 1 / Math.Pow(2, 10));
                dict.Add("Gigabit", 1 / Math.Pow(2, 20));
                dict.Add("Terabit", 1 / Math.Pow(2, 30));
            }
            else if (type == "M")
            {
                dict.Add("bit", Math.Pow(2, 20));
                dict.Add("Kilobit", Math.Pow(2, 10));
                dict.Add("Megabit", Math.Pow(2, 0));
                dict.Add("Gigabit", 1 / Math.Pow(2, 10));
                dict.Add("Terabit", 1 / Math.Pow(2, 20));
            }
            else if (type == "G")
            {
                dict.Add("bit", Math.Pow(2, 30));
                dict.Add("Kilobit", Math.Pow(2, 20));
                dict.Add("Megabit", Math.Pow(2, 10));
                dict.Add("Gigabit", Math.Pow(2, 0));
                dict.Add("Terabit", 1 / Math.Pow(2, 10));
            }
            else if (type == "T")
            {

                dict.Add("bit", Math.Pow(2, 40));
                dict.Add("Kilobit", Math.Pow(2, 30));
                dict.Add("Megabit", Math.Pow(2, 20));
                dict.Add("Gigabit", Math.Pow(2, 10));
                dict.Add("Terabit", Math.Pow(2, 0));
            }

            return dict;
        }
    }
}
 