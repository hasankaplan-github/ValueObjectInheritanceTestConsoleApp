using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValueObjectInheritanceTestConsoleApp.Domain;
using System.Runtime.CompilerServices;

namespace ValueObjectInheritanceTestConsoleApp.Infra.Db.Contexts.Configurations;

public class SpecialCustomerEntityTypeConfiguration : IEntityTypeConfiguration<SpecialCustomer>
{
    public void Configure(EntityTypeBuilder<SpecialCustomer> builder)
    {
        builder.OwnsMany(typeof(SpecialCustomerDocument), "_specialCustomerDocuments", x =>
        {
            x.WithOwner("SpecialCustomer");
            x.Property(typeof(Guid), "Id");
            x.HasKey("Id");
            x.Ignore("Document");

            x.OwnsOne(typeof(DocumentContainer), "_documentContainer", y =>
            {
                y.Property("_type").HasColumnName("document_type");
                y.Property("_issueDate").HasColumnName("document_issue_date");
                y.Property("_serialNumber").HasColumnName("document_serial_number");
                y.Ignore("Document");
            });
        });

        builder.Ignore(x => x.Documents);


        //builder.OwnsMany(x => x.Payments, x =>
        //{
        //    x.WithOwner().HasForeignKey(y => y.OwnerCustomerId);
        //    x.HasKey(y => y.Id);
        //});
    }
}