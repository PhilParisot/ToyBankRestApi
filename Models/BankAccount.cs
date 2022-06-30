using Microsoft.EntityFrameworkCore;

namespace ToyBankRestApi.Models;



public class BankAccount
{
    public BankAccount(string id, int balance)
    {
        Id = id;
        Balance = balance;
    }

    public string Id { get; private set; }
    public int Balance { get; set; }

}
class BankAccountContext : DbContext
{
    public BankAccountContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BankAccount> BankAccounts { get; set; }
}