using Serilog;
using TodoList.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

var log = new LoggerConfiguration()
         .WriteTo.Http("http://localhost:8080", 3000)
         .CreateLogger();

builder.Logging.AddSerilog(log);

// Add services to the container.
builder.AddDatabase()
       .AddDependencies()
       .AddMessageBroken();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionHandler();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
