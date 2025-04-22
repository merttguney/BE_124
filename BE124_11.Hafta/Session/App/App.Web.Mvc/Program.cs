var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    // Session'ýn set ettiði cookie'lerin ayarlarý burada yapýlacak.

    // IsEssential -> Bu cookie olmazsa olmaz anlamýna gelir.
    options.Cookie.IsEssential = true;

    // Cookie'ye isim verme iþlemi
    options.Cookie.Name = "Siliconmade.Session";

    // HttpOnly true yapýldýðýnda JS ile cookie'ye eriþilip içindeki veri okunamaz hale gelir.
    // Güvenliði artýrmak için kullanýlýr.
    options.Cookie.HttpOnly = true;

    // Geçerlilik süresi
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
