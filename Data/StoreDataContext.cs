using Bank.Api.Data.Maps;
using Bank.Api.Models;
using Bank.Api.Models.Operations;
using Microsoft.EntityFrameworkCore;

namespace Bank.Api.Data
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext(DbContextOptions<StoreDataContext> options) : base(options)
        {}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<DepositOperation> DepositOperation { get; set; }

        protected override void  OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountMap());
            builder.ApplyConfiguration(new AbstractOperationMap());
        }

    }
}