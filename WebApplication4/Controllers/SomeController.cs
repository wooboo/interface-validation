using System;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class SomeController : Controller
    {
        [HttpGet]
        public ActionResult View(Guid id)
        {
            return View(new SomeViewModel
            {
                Id = id
            });
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SomeCreateModel());
        }

        [HttpPost]
        public ActionResult Create(SomeCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateCommand(Guid.NewGuid());
                command.Map<INameModel>(model);
                command.Map<IValueModel>(model);

                new SomeCommandBus().Publish(command);

                return View("View", new SomeViewModel
                {
                    Id = command.Id
                }
                    .Map<SomeViewModel, INameModel>(command)
                    .Map<SomeViewModel, IValueModel>(command)
                    );
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(new SomeEditModel
            {
                Id = id
            });
        }

        [HttpPost]
        public ActionResult Edit(Guid id, SomeEditModel model)
        {
            if (ModelState.IsValid)
            {
                var command = new EditCommand(id);
                command.Map<INameModel>(model);
                command.Map<IValueModel>(model);

                new SomeCommandBus().Publish(command);

                return View("View", new SomeViewModel
                {
                    Id = id
                }
                    .Map<SomeViewModel, INameModel>(command)
                    .Map<SomeViewModel, IValueModel>(command)
                    );
            }
            return View(model);
        }
    }
}