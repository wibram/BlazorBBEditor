using BlazorBBEditor.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Globalization;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>( "#app" );
builder.RootComponents.Add<HeadOutlet>( "head::after" );

builder.Services.AddScoped( sp => new HttpClient { BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) } );

//builder.Services.AddBootstrapBlazor();
builder.Services.AddBootstrapBlazor( localizationConfigure: op =>
{
    op.AdditionalJsonAssemblies = new Assembly[]
    {
        typeof( App ).Assembly
    };
} );
builder.Services.Configure<BootstrapBlazor.Components.BootstrapBlazorOptions>( op =>
{
    op.DefaultCultureInfo = "de-DE";
    op.FallbackCulture = "de-DE";
    op.SupportedCultures = new List<string> { "de-DE", "en-US" };
} );

var culture = new CultureInfo( "de-DE" );
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await builder.Build().RunAsync();
