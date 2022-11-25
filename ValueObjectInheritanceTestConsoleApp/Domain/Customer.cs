using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haskap.DddBase.Domain;

namespace ValueObjectInheritanceTestConsoleApp.Domain;

public class Customer : Entity<Guid>
{
    public string Name { get; set; }

    private DocumentContainer _documentContainer = new();
    public Document Document
    {
        get => _documentContainer.Document;
        set => _documentContainer.Document = value;
    }
   
    
    public Customer(Guid id)
        : base(id)
    {

    }
}
