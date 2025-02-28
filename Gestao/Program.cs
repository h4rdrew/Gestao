using Gestao.Components;
using Gestao.Components.Account;
using Gestao.Data;
using Gestao.Domain;
using Gestao.Libaries.Mail;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Google:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Google:ClientSecret")!;
    })
    .AddFacebook(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Facebook:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Facebook:ClientSecret")!;
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Microsoft:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Microsoft:ClientSecret")!;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<SmtpClient>(options =>
{
    var smtpClient = new SmtpClient();
    smtpClient.Host = builder.Configuration.GetValue<string>("EmailSender:Server")!;
    smtpClient.Port = builder.Configuration.GetValue<int>("EmailSender:Port");
    smtpClient.EnableSsl = builder.Configuration.GetValue<bool>("EmailSender:SSL");
    smtpClient.Credentials = new NetworkCredential(
        builder.Configuration.GetValue<string>("EmailSender:User"),
        builder.Configuration.GetValue<string>("EmailSender:Password"));

    return smtpClient;
});
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Gestao.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
