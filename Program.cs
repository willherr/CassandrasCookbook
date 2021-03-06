﻿using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blazored.LocalStorage;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using CassandrasCookbook.Shared.Recipe;
using MatBlazor;
using System.Net.Http.Json;

namespace CassandrasCookbook
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services
                .AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddHeadElementHelper()
                .AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true)
                .AddSingleton(async p => await p.GetRequiredService<HttpClient>().GetFromJsonAsync<IEnumerable<RecipeItem>>("data/recipes.json").ConfigureAwait(false)); ;

            await builder.Build().RunAsync();
        }
    }
}
