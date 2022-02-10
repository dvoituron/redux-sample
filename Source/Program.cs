using ReduxSample.Models;
using ReduxSample.Pages.CounterManagement;
using ReduxSample.Redux;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<DataService>();

builder.Services.AddScoped<Container<CounterState>>(provider =>
{
    return new
    (
        initialState: CounterStateReducers.InitialState,
        reducers: CounterStateReducers.Create(),
        effects: new[]
        {
            // Subscribers
            new CounterDecrementEffect(),
        }
    );
});

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
