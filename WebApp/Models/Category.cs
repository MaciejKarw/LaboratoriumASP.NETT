using System.ComponentModel.DataAnnotations;

public enum Category
{
    [Display(Name = "Rodzina", order = 1)]
    Family,
    [Display(Name = "Rodzina", order = 3)]
    Friend,
    [Display(Name = "Rodzina", order = 2)]
    Business,
}