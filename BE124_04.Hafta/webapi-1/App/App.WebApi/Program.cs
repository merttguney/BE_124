var builder = WebApplication.CreateBuilder(args);

// ------------ 1. KISIM -----------------

// builder objesi üzerinden, uygulama içerisinde ne gibi yapýlarýn olacaðýnýn belirlendiði kýsým
// uygulama içerisinde var olaca yapýlar bu kýsýmda eklenir.

// Add services to the container.

builder.Services.AddControllers(); // uygtulama içerisine controller yapýsýnýn dahil edilmesi
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // endpoint yapýsýnýn dahil edilmesi
builder.Services.AddSwaggerGen(); // Swagger dahil edilmesi

var app = builder.Build(); // builder objesi üzerinden dahil edilen yapýlar ile birlikte uygulamanýn kurulmasý (build edilmesi) saðlanýr. Bir web uygulamasý oluþmuþ olur. Bu oluþan uygulama "app" deðiþkenine atanýr.

// ------------ 2. KISIM -----------------

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // eðer uygulama geliþtirme ortamýndaysa swagger kullan
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Https (güvenlik sertifikalý http) kullan

app.UseAuthorization(); // yetkilendirme ile ilgili kýsým.

app.MapControllers(); // Request'lere controller'lar (var ise) response üretsin.

app.Run();
