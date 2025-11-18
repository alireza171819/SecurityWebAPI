var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var WebaAPIAllowSpecificOrigins = "_webAPIAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: WebaAPIAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader().WithMethods("PUT", "DELETE", "GET")
            .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services
    .AddConfig(builder.Configuration)
    .AddDependencyGroup();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(WebaAPIAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
