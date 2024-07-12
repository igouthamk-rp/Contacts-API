using Microsoft.EntityFrameworkCore;
using Web_API_1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Some services are injected to it

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add ContactsAPIDBContext here
//using IN Memory Database
//builder.Services.AddDbContext<ContactsAPIDbContext>(options => options.UseInMemoryDatabase("ContactsDb"));
//using SSMS
builder.Services.AddDbContext<ContactsAPIDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ContactsAPIConnectionString")));

// Croos origin resource sharing
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
