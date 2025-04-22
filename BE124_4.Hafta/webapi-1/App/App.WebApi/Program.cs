var builder = WebApplication.CreateBuilder(args);

// ------------ 1. KISIM -----------------

// builder objesi �zerinden, uygulama i�erisinde ne gibi yap�lar�n olaca��n�n belirlendi�i k�s�m
// uygulama i�erisinde var olaca yap�lar bu k�s�mda eklenir.

// Add services to the container.

builder.Services.AddControllers(); // uygtulama i�erisine controller yap�s�n�n dahil edilmesi
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // endpoint yap�s�n�n dahil edilmesi
builder.Services.AddSwaggerGen(); // Swagger dahil edilmesi

var app = builder.Build(); // builder objesi �zerinden dahil edilen yap�lar ile birlikte uygulaman�n kurulmas� (build edilmesi) sa�lan�r. Bir web uygulamas� olu�mu� olur. Bu olu�an uygulama "app" de�i�kenine atan�r.

// ------------ 2. KISIM -----------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // e�er uygulama geli�tirme ortam�ndaysa swagger kullan
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Https (g�venlik sertifikal� http) kullan

app.UseAuthorization(); // yetkilendirme ile ilgili k�s�m.

app.MapControllers(); // Request'lere controller'lar (var ise) response �retsin.

app.Run();
