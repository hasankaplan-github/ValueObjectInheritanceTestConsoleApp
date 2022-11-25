using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValueObjectInheritanceTestConsoleApp.Domain;
using System.Runtime.CompilerServices;

namespace ValueObjectInheritanceTestConsoleApp.Infra.Db.Contexts.Configurations;

public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.OwnsOne(typeof(DocumentContainer), "_documentContainer", x =>
        {
            x.Property("_type").HasColumnName("document_type");
            x.Property("_issueDate").HasColumnName("document_issue_date");
            x.Property("_serialNumber").HasColumnName("document_serial_number");
            x.Ignore("Document");
        });

        builder.Ignore(x => x.Document);


        //builder.OwnsMany(x => x.Payments, x =>
        //{
        //    x.WithOwner().HasForeignKey(y => y.OwnerCustomerId);
        //    x.HasKey(y => y.Id);
        //});
    }
}