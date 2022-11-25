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







