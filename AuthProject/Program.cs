var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.Cookie.Name = "Grandmas.Cookie";
        config.LoginPath = "/Home/Authenticate";
    });

builder.Services.AddControllersWithViews();



var app = builder.Build();




app.UseRouting();

//are you allowed?
app.UseAuthorization();
//who are you?
app.UseAuthentication();


app.UseEndpoints(t =>
{
    t.MapDefaultControllerRoute();
});

app.MapGet("/", () => "Hello World!");


app.Run();
