using ValueObjectInheritanceTestConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ValueObjectInheritanceTestConsoleApp.Domain;
public class DocumentContainer
{
    private Guid _id;

    private DocumentType _type;
    private DateTime? _issueDate;
    private string? _serialNumber;


    public Document Document 
    {
        get
        {
            switch (_type)
            {
                case DocumentType.IdentityCard:
                    return new IdentityCard(_issueDate.Value) { Id = _id };

                case DocumentType.Passport:
                    return new Passport(_serialNumber) { Id = _id };

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        set
        {
            _id = value.Id;

            switch (value)
            {
                case IdentityCard identityCard:
                    _issueDate = identityCard.IssueDate;
                    _serialNumber = null;
                    _type = DocumentType.IdentityCard;
                    break;

                case Passport passport:
                    _issueDate = null;
                    _serialNumber = passport.SerialNumber;
                    _type = DocumentType.Passport;
                    break;
            }
        }
    }
}
