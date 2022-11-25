using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectInheritanceTestConsoleApp.Domain;

public class Passport : Document
{
    public string SerialNumber { get; set; }

    private Passport()
    {

    }

    public Passport(string serialNumber)
    {
        SerialNumber = serialNumber;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return SerialNumber;
    }
}
