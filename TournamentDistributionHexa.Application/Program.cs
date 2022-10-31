using Microsoft.EntityFrameworkCore;
using TournamentDistributionHexa.Domain.Repositories;
using TournamentDistributionHexa.Domain.Tournaments;
using TournamentDistributionHexa.Infrastructure.Models;
using TournamentDistributionHexa.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<ITournamentDomain, TournamentDomain>();
builder.Services.AddScoped<ITournamentMatchRepository, TournamentMatchRepositoryAdapter>();
builder.Services.AddDbContext<RepartitionTournoiContext>(
    options => options.UseSqlServer("name=ConnectionStrings:RepartitionTournoiContext"));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
