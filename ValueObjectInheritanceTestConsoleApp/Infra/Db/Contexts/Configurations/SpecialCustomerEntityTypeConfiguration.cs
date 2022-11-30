using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ValueObjectInheritanceTestConsoleApp.Domain;
using System.Runtime.CompilerServices;

namespace ValueObjectInheritanceTestConsoleApp.Infra.Db.Contexts.Configurations;

public class SpecialCustomerEntityTypeConfiguration : IEntityTypeConfiguration<SpecialCustomer>
{
    public void Configure(EntityTypeBuilder<SpecialCustomer> builder)
    {
        builder.OwnsMany(typeof(DocumentContainer), "_documentContainers", x =>
        {
            x.WithOwner().HasForeignKey("SpecialCustomerId");
            x.Property<Guid>("_id").HasColumnName("id");
            x.HasKey("_id");
            x.Ignore("Document");

            x.Property("_type").HasColumnName("document_type");
            x.Property("_serialNumber").HasColumnName("document_serial_number");
            x.Property("_issueDate").HasColumnName("document_issue_date");
        });

        builder.Ignore(x => x.Documents);


        //builder.OwnsMany(x => x.Payments, x =>
        //{
        //    x.WithOwner().HasForeignKey(y => y.OwnerCustomerId);
        //    x.HasKey(y => y.Id);
        //});
    }
}