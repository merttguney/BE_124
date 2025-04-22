using App.Web.Mvc.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth-cookie";
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;

        //options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

        options.LoginPath = "/Auth/Login"; // login olmamýþ kiþi nereye yönlendirilsin.

        options.AccessDeniedPath = "/Auth/AccessDenied"; // yetkisiz giriþlerde buraya yönlendirilsin...

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ----------------------------
app.UseAuthentication();
// ----------------------------

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (await dbContext.Database.EnsureCreatedAsync()) // oluþturduysa true döndürür
    {
        // seed

        await DbSeeder.SeedAsync(dbContext);
    }
}
app.Run();


//  * Uygulamaya Register seçeneði eklenecek. (Kullanýcý kayýt formu)
//	* Uygulamaya kayýt olan her kullanýcý direkt olarak Login olamayacak
//	* Register iþlemi gerçekleþtirmiþ kiþileri, Admin olarak giriþ yapmýþ kiþiler görüntüleyebilecek.
//	* Bu listede onaylanmamýþ kiþilerin isimlerini yanýnda "Onayla" butonu olacak.
//	* Admin'in onayladýðý kiþiler bu iþlemden sonra Login olabilecek.

//	* UserEntity'de, ilgili user onaylý mý deðil mi bilgisini tutulacaðý bir property eklenmeli (bool)
//	* Register olan her kullanýcý için bu property'nin default deðeri false olmalý.
//	* Bu property'si false olan kiþiler Login olamayacak.
