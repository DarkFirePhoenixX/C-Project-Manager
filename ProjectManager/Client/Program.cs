using System;
using System.Net.Http;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Client;
using ProjectManager.Client.Services;
using ProjectManager.Shared.Interfaces;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ProjectManager.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ProjectManager.ServerAPI"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<INavService, NavService>();
builder.Services.AddScoped<ITicket, TicketService>();
builder.Services.AddScoped<IUser, UserService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<IProject, ProjectService>();
builder.Services.AddScoped<IReport, ReportService>();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
