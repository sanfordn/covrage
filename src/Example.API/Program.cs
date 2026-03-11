using Covrage.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddCovrageServices();
builder.Services.AddCovrageInfrastructure();
builder.Services.AddCovrageApi();

var app = builder.Build();

app.UseCovrage();
app.MapCovrageApi();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Covrage API v1");
});

app.UseHttpsRedirection();

app.Run();
