using Bank.Api.Models.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Api.Data.Maps
{
    public class AbstractOperationMap : IEntityTypeConfiguration<AbstractOperation>
    {
        public void Configure(EntityTypeBuilder<AbstractOperation> builder)
        {
            builder.ToTable("operation");

            builder.HasKey(operation => operation.Id);

            builder.HasDiscriminator<string>("OperationType");
            builder.Property(operation => operation.OperationType)
                .HasMaxLength(200);

            builder.Property(operation => operation.Description)
                .IsRequired()
                .HasMaxLength(255);
            
            builder.Property(operation => operation.Rate).IsRequired().HasColumnType("money");
            builder.Property(operation => operation.Amount).IsRequired().HasColumnType("money");
            builder.Property(operation => operation.Date).IsRequired().HasColumnType("datetime");
            
            builder.HasOne(operation => operation.Account)
                .WithMany(account => account.Operations)
                .HasForeignKey(operation => operation.AccountNumber);         
        }
    }
}