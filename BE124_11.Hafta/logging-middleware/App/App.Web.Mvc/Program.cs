using App.Web.Mvc.Middlewares;
using App.Web.Mvc.Models.Config;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLogging(options =>
{
    options.ClearProviders();

    //options.AddConsole();

    //options.AddEventLog();

    options.AddConsole();

});

builder.Services.Configure<UserConfigModel>(builder.Configuration.GetSection("User"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// 1)
// ----------------------------
//app.Use(async (context, next) =>
//{
//    context.Response.Headers["X-Ornek"] = "BE124";
//    await next();
//});

// 2)
// -------------------------------


//app.Use(async (context, next) =>
//{
//    // logger i�in bir scope olu�turmak gerekiyor

//    using var scope = app.Services.CreateScope();

//    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

//    try
//    {
//        await next();

//        logger.LogInformation("{tarih} - {path} adresine {method} iste�inde bulunuldu.", DateTime.Now, context.Request.Path, context.Request.Method);

//        if (context.Response.StatusCode < 500 && context.Response.StatusCode >= 400)
//        {
//            logger.LogWarning("{tarih} - {path} adresi {statusCode} cevab� verdi.", DateTime.Now, context.Request.Path, context.Response.StatusCode);
//        }
//    }
//    catch (Exception ex)
//    {
//        logger.LogError(ex,"Bir hata olu�tu.");
//        throw;
//    }

//});


// 3)
// -------------------------------

//app.UseMiddleware<RequestLoggerMiddleware>();


// 4)
// -------------------------------

app.UseMiddleware<ExampleMiddleware>();


app.UseHttpsRedirection(); // gelen sitekleri https'li oalcak �ekilde y�nlendirir
app.UseStaticFiles(); // wwwroot klas�r�ndeki statik dosyalar�n okunmas�n�n sa�lar

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
