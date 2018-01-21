using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MvcModels_WebApp.Models;

namespace MvcModels_WebApp.Models 
{
    public class HomeController : Controller 
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repo) => _repository = repo;

        public IActionResult Index([FromQuery]int? id)
        {
            Person person = null;
            if (id.HasValue && (person = _repository[id.Value]) != null)
            {
                return View(person);
            }
            else
            {
                return NotFound();
            }
        }

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        public ViewResult DisplaySummary([Bind(Prefix=nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        public ViewResult Names(IList<string> names) => View(names ?? new List<string>());

        public ViewResult Address(IList<AddressSummary> addresses) => View(addresses ?? new List<AddressSummary>());

        public ViewResult Header(HeaderModel model) => View(model);

        public ViewResult Body() => View();

        [HttpPost]
        public Person Body([FromBody]Person model) => model;
    }
}