using Covrage;
using Covrage.DependencyInjection;
using Example.API.Domain.Services;
using Example.API.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCovrage();
builder.Services.AddSingleton<IPolicyDatabase, InMemoryPolicyDatabase>();
builder.Services.AddControllers(options =>
    {
        options.ModelBinderProviders.Insert(0, new PolicyModelBinderProvider());
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCovrage();

app.UseAuthorization();

app.MapControllers();

app.Run();


