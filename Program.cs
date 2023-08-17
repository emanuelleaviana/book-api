using book_api_alpha.Model;
using book_api_alpha.Repositories;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        var connectionSring = "AccountEndpoint=https://book-api2.documents.azure.com:443/;AccountKey=NBpbrNbcW0yFewVclLWA18G2tUFdcGyvUDO05yZItiOSCUKMx9JscbtQ2ihZ9NQLhCHrE3aTcRmAACDbRaWXmw==;";
        var dbName = "MyStore";
        builder.Services.AddDbContext<BookContext>(x => x.UseCosmos(connectionSring, dbName));
        builder.Services.AddScoped<IBookRepository, BookRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}