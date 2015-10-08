using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using WebApplication4.Validation;

namespace WebApplication4.Controllers
{
    public class SomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SomeViewModel());
        }

        [HttpPost]
        public ActionResult Index(SomeOtherViewModel model)
        {
            var command = new SomeCommand()
            {
                Name = model.Name,
                Value = model.Value
            };
            var valFact = new MyValidatorFactory();
            var validator = valFact.GetValidator<SomeCommand>();
            var result = validator.Validate(command);

            return View(new SomeViewModel()
            {
                Name = model.Name,
                Value = model.Value
            });
        }
    }
}