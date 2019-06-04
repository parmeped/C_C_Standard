using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Persistance
{
    class DatabaseInitializer 
        : CreateDatabaseIfNotExists<DatabaseService>
    {
        protected override void Seed(DatabaseService database)
        {
            base.Seed(database);
            CreateMembers(database);            
        }

        private void CreateMembers(DatabaseService database)
        {
            Chargeable chargeable = new Chargeable() { Active = true, Id = 1, Name = "Cuota Activo", Value = 100 };
            Chargeable chargeable1 = new Chargeable() { Active = true, Id = 2, Name = "Cuota Vitalicio", Value = 300 };
            Chargeable chargeable3 = new Chargeable() { Active = true, Id = 3, Name = "Pileta", Value = 200 };

            BalanceSheet balanceSheet = new BalanceSheet() { Expenses = new List<Expense>(), Payments = new List<Payment>()};
            BalanceSheet balanceSheet1 = new BalanceSheet() { Expenses = new List<Expense>(), Payments = new List<Payment>() };


            Expense ex1 = new Expense() { Id = 1, DateTime = DateTime.Now.AddDays(-1), Chargeable = chargeable };
            Expense ex2 = new Expense() { Id = 2, DateTime = DateTime.Now.AddDays(-5), Chargeable = chargeable1 };
            Expense ex3 = new Expense() { Id = 3, DateTime = DateTime.Now.AddDays(-10), Chargeable = chargeable };
            Expense ex4 = new Expense() { Id = 4, DateTime = DateTime.Now.AddDays(-15), Chargeable = chargeable1 };
            Expense ex5 = new Expense() { Id = 5, DateTime = DateTime.Now.AddDays(-15), Chargeable = chargeable1 };
            Expense ex6 = new Expense() { Id = 6, DateTime = DateTime.Now.AddDays(-20), Chargeable = chargeable };
            Expense ex7 = new Expense() { Id = 7, DateTime = DateTime.Now.AddDays(-15), Chargeable = chargeable3 };
            List<Expense> expList = new List<Expense>();
            List<Expense> expList1 = new List<Expense>();

            expList.Add(ex1);
            expList.Add(ex2);

            expList1.Add(ex5);
            expList1.Add(ex6);
            expList1.Add(ex7);

            Payment pay1 = new Payment() { Id = 1, DateTime = DateTime.Now, ExpensesPaid = expList, Total = 400 };
            pay1.calculateTotal();
            Payment pay2 = new Payment() { Id = 2, DateTime = DateTime.Now, ExpensesPaid = expList1, Total = 600 };


            balanceSheet.Expenses.Add(ex1);
            balanceSheet.Expenses.Add(ex2);
            balanceSheet.Expenses.Add(ex3);
            balanceSheet.Expenses.Add(ex4);
            balanceSheet.Payments.Add(pay1);
            balanceSheet.netBalance();

            balanceSheet1.Expenses.Add(ex5);
            balanceSheet1.Expenses.Add(ex6);
            balanceSheet1.Expenses.Add(ex7);
            balanceSheet.Payments.Add(pay2);
            balanceSheet1.netBalance();

            Category category = new Category() { Id = 1, Name = "Socio Activo", Chargeable = chargeable };
            Category category2 = new Category() { Id = 2, Name = "Socio Vitalicio", Chargeable = chargeable1 };
            Member member = new Member() { Name = "Pedro Parmeggiani", Category = category, BirthDate = DateTime.Now.AddDays(-3000), BalanceSheet = balanceSheet };
            Member member2 = new Member() { Name = "Juan Carlos", Category = category2, BirthDate = DateTime.Now.AddDays(-2000), BalanceSheet = balanceSheet1 };
            database.Members.Add(member);
            database.Members.Add(member2);

            database.SaveChanges();
        }
    }
}
