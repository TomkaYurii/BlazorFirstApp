var builder = WebApplication.CreateBuilder(args);


//Adding support for Razor Pages in the app since Blazor needs Razor Pages to work
builder.Services.AddRazorPages();

//Àdd Server-Side Blazor services to the service collection
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Blazor Configurations
// We have to integrates Blazor with ASP.NET Core Endpoint Routing. 
// This will let SignalR which is the part of ASP.NET Core that handles 
// the persistent HTTP request to work properly.
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
