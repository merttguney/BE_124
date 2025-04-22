var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// 1)

app.MapGet("/hi", () =>
{
    return "Siliconmade Academy";
}).WithOpenApi();


// 2)

int i = 0;

app.MapGet("/say", () =>
{
    return i++;
}).WithOpenApi();


// 3)

List<string> list = new()
{
    "Ali", "Veli", "Ayþe"
};

int counter = 0;

app.MapGet("/list", () =>
{
    int index = counter % 3;
    counter++;
    return list[index];
}).WithOpenApi();

// 4) 

List<string> names = new()
{
    "Aslý", "Güney", "Merve"
};

app.MapGet("/ornek", () =>
{
    var joinedItems = string.Join(", ", names);
    return joinedItems;
}).WithOpenApi();



app.Run();

