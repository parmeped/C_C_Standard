using Application;
using Domain;
using Domain.Common;
using Persistence;
using System.Data.Entity;

namespace Persistance
{
    public class DatabaseService 
        : DbContext
        , IDatabaseService
    {
        public IDbSet<Member> Members { get; set; }
        public IDbSet<Category> Categories { get; set; }       
        public IDbSet<Chargeable> Chargeables { get; set; }
        public IDbSet<BalanceSheet> BalanceSheets { get; set; }
        public IDbSet<Expense> Expenses { get; set; }
        public IDbSet<Payment> Payments { get; set; }


        public DatabaseService() : base("CCTEST")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new MemberConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new ChargeableConfiguration());
            modelBuilder.Configurations.Add(new BalanceSheetConfiguration());
            modelBuilder.Configurations.Add(new ExpenseConfiguration());
            modelBuilder.Configurations.Add(new PaymentConfiguration());
        }
    }
}