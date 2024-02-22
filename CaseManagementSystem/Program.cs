using CaseManagementSystem.Data.AgencyTypes;
using CaseManagementSystem.Data.CaseProfiles;
using CaseManagementSystem.Data.Cases;
using CaseManagementSystem.Data.CaseTypes;
using CaseManagementSystem.Data.Companies;
using CaseManagementSystem.Data.Auth;
using CaseManagementSystem.Data.Subjects;
using CaseManagementSystem.Data.TimeLimits;
using CaseManagementSystem.Data.TitlePrefixes;
using CaseManagementSystem.Data.TraceLevels;
using CaseManagementSystem.Data.TraceReason;
using CaseManagementSystem.Data.TraceResults;
using CaseManagementSystem.Data.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using CaseManagementSystem.Data.AgencyTypeCaseProfile;
using CaseManagementSystem.Data.Documents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // Your token validation parameters (issuer, audience, etc.)
            };
        });

// Configure authorization policies if needed
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "Admin"));
    // Add more policies as needed for different roles or claims
});
// Register custom service
builder.Services.AddSingleton<CustomAuthenticationStateProvider>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<CompaniesService>();
builder.Services.AddSingleton<CountryService>();
builder.Services.AddSingleton<AgencyTypeService>();
builder.Services.AddSingleton<CaseTypeService>();
builder.Services.AddSingleton<CaseService>();
builder.Services.AddSingleton<TraceLevelService>();
builder.Services.AddSingleton<TraceReasonService>();
builder.Services.AddSingleton<SubjectService>();
builder.Services.AddSingleton<CaseProfileService>();
builder.Services.AddSingleton<TimeLimitService>();
builder.Services.AddSingleton<TitlePrefixeService>();
builder.Services.AddSingleton<TraceResultsService>();
builder.Services.AddSingleton<AgencyTypeCaseProfileService>();
builder.Services.AddSingleton<DocumentService>();
// Mud blazor UI
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
