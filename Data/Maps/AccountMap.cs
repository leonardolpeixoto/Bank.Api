using Bank.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bank.Api.Data.Maps
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account");
            builder.HasKey(account => account.AccountNumber);
            builder.Property(account => account.Balance).IsRequired().HasColumnType("money");
        }
    }
}