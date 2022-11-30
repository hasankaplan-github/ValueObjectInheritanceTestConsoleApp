using Haskap.DddBase.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectInheritanceTestConsoleApp.Domain;

public abstract class Document : ValueObject
{
    public Guid Id { get; init; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        return Enumerable.Empty<object>();
    }
}
