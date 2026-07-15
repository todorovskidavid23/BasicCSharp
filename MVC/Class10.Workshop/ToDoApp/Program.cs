using ToDoApp.DataAccess.Implementations;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Services.Implementations;
using ToDoApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ovde se pravi Dependency Injections for repository
builder.Services.AddScoped<IRepository<ToDo>, ToDoRepository>();
//builder.Services.AddScoped<IRepository<IToDoRepository>, ToDoRepository>();
//prvo sto da zeme koe repository , koja implemetacija da ja zeme
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Status>, StatusRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();




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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
