using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haskap.DddBase.Domain;

namespace ValueObjectInheritanceTestConsoleApp.Domain;

public class SpecialCustomer : Entity<Guid>
{
    public string Name { get; set; }

    private List<DocumentContainer> _documentContainers = new();
    public IReadOnlyCollection<Document> Documents =>
        _documentContainers
        .Select(x => x.Document)
        .ToList()
        .AsReadOnly();
    public SpecialCustomer(Guid id)
        : base(id)
    {

    }

    public void AddDocument(Document document)
    {
        _documentContainers.Add(new DocumentContainer { Document = document });
    }
}
