using AWESOME.Data;
using AWESOME.Data.Seed;
using AWESOME.Services.Implementations;
using AWESOME.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// KESTREL
// ==========================

builder.WebHost.UseUrls("http://0.0.0.0:5001");

// ==========================
// DATABASE AWESOME
// ==========================

builder.Services.AddDbContext<AwesomeDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AwesomeConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        }
    )
);

// ==========================
// DATABASE SCL
// ==========================

builder.Services.AddDbContext<SclDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SclConnection"),
        sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        }
    )
);

// ==========================
// SERVICES
// ==========================

builder.Services.AddScoped<IAuthService, AuthService>();

// ==========================
// AUTHENTICATION
// ==========================

builder.Services
    .AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/Login";

        options.ExpireTimeSpan =
            TimeSpan.FromHours(10);

        options.SlidingExpiration = true;
    });

// ==========================
// AUTHORIZATION
// ==========================

builder.Services.AddAuthorization();

// ==========================
// MVC
// ==========================

builder.Services.AddControllersWithViews();

// ==========================
// GLOBALIZACION
// ==========================

var culture = new CultureInfo("en-US");

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// ==========================
// BUILD
// ==========================

var app = builder.Build();

// ==========================
// LOGS
// ==========================

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseDeveloperExceptionPage(); // temporal
}

// ==========================
// DATABASE MIGRATION
// AWESOME
// ==========================

var retries = 10;
var delay = TimeSpan.FromSeconds(15);

for (int i = 1; i <= retries; i++)
{
    try
    {
        using var scope =
            app.Services.CreateScope();

        var context =
            scope.ServiceProvider
                .GetRequiredService<AwesomeDbContext>();

        context.Database.Migrate();

        DbInitializer.Initialize(context);

        Console.WriteLine(
            "Base de datos AWESOME lista.");

        break;
    }
    catch (Exception ex)
    {
        var logPath =
            @"C:\inetpub\wwwroot\AWESOME\logs\db-startup.txt";

        Directory.CreateDirectory(
            Path.GetDirectoryName(logPath)!);

        File.AppendAllText(
            logPath,
            $"[{DateTime.Now}] Intento {i} falló:{Environment.NewLine}{ex}{Environment.NewLine}{Environment.NewLine}");

        if (i == retries)
        {
            throw;
        }

        Thread.Sleep(delay);
    }
}

// ==========================
// PIPELINE
// ==========================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// ==========================
// ROUTING
// ==========================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();