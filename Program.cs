using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ToyBankRestApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BankAccountContext>(opt => opt.UseSqlite("Data Source=Pizzas.db"));
// Learn more about configuring Swagger/OpenAPI at https://aka.mspersevered/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.MapControllers();

app.MapGet("/bankaccounts/{id}", async (BankAccountContext db, string id) => await db.BankAccounts.FindAsync(id));

app.MapPost("/bankaccounts", async (BankAccountContext db, BankAccount bankAccount) =>
{
    await db.BankAccounts.AddAsync(bankAccount);
    await db.SaveChangesAsync();
    return Results.Created($"/bankaccounts/{bankAccount.Id}", bankAccount);
});

app.Run();
