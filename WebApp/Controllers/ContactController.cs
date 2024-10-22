using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{

    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Dobry",
                Email = "dobry@gmail.com",
                PhoneNumber = "222 666 444",
                BirthDate = new (2003, 10, 10)
            }
        },
        {
            2,
            new()
            {
                Id = 2,
                FirstName = "Krzysiek",
                LastName = "Miły",
                Email = "mily@gmail.com",
                PhoneNumber = "254 875 654",
                BirthDate = new (2004, 03, 5)
            }
        },
        {
            3,
            new()
            {
                Id = 3,
                FirstName = "Kocham",
                LastName = "Emiśke",
                Email = "janek@gmail.com",
                PhoneNumber = "421 543 466",
                BirthDate = new (2004, 12, 19)
            }
        },
    };

    private static int currentId = 3;
    // Lista kontaktów, przycisk dodawania kontaktu
    public IActionResult Index()
    {
        return View(_contacts); 
    }
    // formularz dodawania kontaktu
    public IActionResult Add()
    {
        return View();
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
        _contacts.Add(model.Id,model);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }

    public IActionResult Details()
    {
        throw new NotImplementedException();
    }
}