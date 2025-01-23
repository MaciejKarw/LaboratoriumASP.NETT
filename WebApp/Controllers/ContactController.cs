using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        private static int currentId = 3;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        public IActionResult Index()
        {
            return View(_contactService.GetAll());
        }
        
        public IActionResult Details(int id)
        {
            return View(_contactService.GetById(id));
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Id = ++currentId;
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_contactService.GetById(id));
        }
        
        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _contactService.Update(model);
            return RedirectToAction(nameof(Index));
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
