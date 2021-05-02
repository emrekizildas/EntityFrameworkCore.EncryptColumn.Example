using EntityFrameworkCore.EncryptColumn.Example.Context;
using EntityFrameworkCore.EncryptColumn.Example.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore.EncryptColumn.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("User adding...");
            ExampleDbContext dbContext = new();
            User newUser = new()
            {
                Firstname = "Emre",
                Lastname = "Kizildas",
                EmailAddress = "kizildas@icloud.com",
                IdentityNumber = "12345678901"
            };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();
            Console.WriteLine("User added!");
            Console.WriteLine("-----");
            Console.WriteLine("User listing...");
            List<User> users = dbContext.Users.ToList();
            foreach (User user in users)
            {
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine($"Firstname: {user.Firstname}");
                Console.WriteLine($"Lastname: {user.Lastname}");
                Console.WriteLine($"Email Address: {user.EmailAddress}");
                Console.WriteLine($"Identity Number: {user.IdentityNumber}");
            }
            Console.ReadKey();
        }
    }
}
