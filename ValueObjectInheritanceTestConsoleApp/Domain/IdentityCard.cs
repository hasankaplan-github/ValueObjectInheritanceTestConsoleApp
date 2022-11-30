using ValueObjectInheritanceTestConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueObjectInheritanceTestConsoleApp.Domain;
public class IdentityCard : Document
{
    public DateTime IssueDate { get; private set; }

    private IdentityCard()
    {

    }

    public IdentityCard(DateTime issueDate)
    {
        IssueDate = issueDate;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return IssueDate;
    }
}
