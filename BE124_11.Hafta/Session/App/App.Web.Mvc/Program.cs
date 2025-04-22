var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    // Session'�n set etti�i cookie'lerin ayarlar� burada yap�lacak.

    // IsEssential -> Bu cookie olmazsa olmaz anlam�na gelir.
    options.Cookie.IsEssential = true;

    // Cookie'ye isim verme i�lemi
    options.Cookie.Name = "Siliconmade.Session";

    // HttpOnly true yap�ld���nda JS ile cookie'ye eri�ilip i�indeki veri okunamaz hale gelir.
    // G�venli�i art�rmak i�in kullan�l�r.
    options.Cookie.HttpOnly = true;

    // Ge�erlilik s�resi
    options.IdleTimeout = TimeSpan.FromMinutes(20);
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

// Session Kullan
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
