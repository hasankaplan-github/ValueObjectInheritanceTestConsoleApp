using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectInheritanceTestConsoleApp.Domain;
public class SpecialCustomerDocument
{
    public SpecialCustomer SpecialCustomer { get; set; }

    private DocumentContainer _documentContainer = new();
    public Document Document 
    {
        get => _documentContainer.Document;
        set => _documentContainer.Document = value;
    }
}
