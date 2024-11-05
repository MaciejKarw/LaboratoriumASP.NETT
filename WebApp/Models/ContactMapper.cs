﻿namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel arg)
    {
        return new ContactEntity()
        {
            Id = arg.Id,
            LastName = arg.LastName,
            FirstName = arg.FirstName,
            BirthDate = arg.BirthDate,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email
        };
    }

    public static ContactModel FromEntity(ContactEntity arg)
    {
        return new ContactModel()
        {
            Id = arg.Id,
            LastName = arg.LastName,
            FirstName = arg.FirstName,
            BirthDate = arg.BirthDate,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email
        };
    }
}