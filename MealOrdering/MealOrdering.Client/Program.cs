using Blazored.Modal;
using Blazored.Modal.Services;
using MealOrdering.Client.Utilis;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<ModalManager>();

builder.Services.AddBlazoredModal();


await builder.Build().RunAsync();
