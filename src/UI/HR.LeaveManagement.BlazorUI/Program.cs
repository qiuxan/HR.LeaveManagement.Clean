using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using HR.LeaveManagement.BlazorUI;
using HR.LeaveManagement.BlazorUI.Services.Base;
using Microsoft.Extensions.DependencyInjection; // Add this using directive
using System.Net.Http;
using System.Reflection;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services; // Add this using directive

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IClient, Client>(client=>client.BaseAddress = new Uri("https://localhost:7276"));

builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
