using AnimaxMissionControlPortal.Components;
using AnimaxMissionControlPortal.Data;
using AnimaxMissionControlPortal.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AnimaxDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AnimaxDb") ?? "Data Source=Data/animax-mission-control.db"));
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<MissionService>();
builder.Services.AddScoped<DivisionService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<DemoPersonaService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AnimaxDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
    await scope.ServiceProvider.GetRequiredService<SeedService>().EnsureSeededAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
