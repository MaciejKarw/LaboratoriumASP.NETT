using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    private static int currentId = 3;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // Lista kontaktów, przycisk dodawania kontaktu
    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }
    // formularz dodawania kontaktu

    public ActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }

    public IActionResult Add()
    {
        return View();

        _contactService.Add(model);
        return RedirectToAction(nameof(Index));
    }

    // Odebranie danych z formularza, walidacja i dodanie kontatku do kolekcji
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            // wyswietlenie ponowne formularza z błędami
            return View(model);
        }

        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _contactService.Update(model);
        return RedirectToAction(nameof(System.Index));
    }

    public ActionResult Delete(int id, ContactModel model)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}