// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using ValueObjectInheritanceTestConsoleApp;
using ValueObjectInheritanceTestConsoleApp.Domain;
using System.Collections;
using System.Dynamic;
using System.Security.Cryptography;
using ValueObjectInheritanceTestConsoleApp.Infra.Db.Contexts;

Console.WriteLine("Hello, World!");

//referance https://enterprisecraftsmanship.com/posts/hierarchy-value-objects/


using var db = new TestDbContext();

var customer = new Customer(Guid.NewGuid())
{
    Name = "hasan",
    Document = new Passport("111")
};
db.Customer.Add(customer);
db.SaveChanges();


var customer2 = db.Customer
    .Where(x => x.Name == "hasan")
    .FirstOrDefault();

Console.WriteLine(customer2.Document.GetType().Name);


var specialCustomer = new SpecialCustomer(Guid.NewGuid())
{
    Name = "special customer"
};

specialCustomer.AddDocument(new Passport("1234"));
specialCustomer.AddDocument(new IdentityCard(DateTime.UtcNow));
db.SpecialCustomer.Add(specialCustomer);
db.SaveChanges();

var specialCustomer2 = db.SpecialCustomer
    .FirstOrDefault();

Console.WriteLine(specialCustomer2.Documents.Count);

foreach (var document in specialCustomer2.Documents)
{
    switch (document)
    {
        case Passport passport:
            Console.WriteLine("----");
            Console.WriteLine(passport.GetType().Name);
            Console.WriteLine(passport.Id);
            Console.WriteLine(passport.SerialNumber);
            Console.WriteLine("----");
            break;
        case IdentityCard identityCard:
            Console.WriteLine("----");
            Console.WriteLine(identityCard.GetType().Name);
            Console.WriteLine(identityCard.Id);
            Console.WriteLine(identityCard.IssueDate);
            Console.WriteLine("----");
            break;
        default:
            break;
    }
}







