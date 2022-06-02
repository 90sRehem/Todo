using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder);
ConfigureMvc(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.UseCors(x =>
    x.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.Run();

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder
      .Services
      .AddControllers()
      .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
      .AddJsonOptions(x =>
      {
          x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
          x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
      });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<ITodoRepository, TodoRepository>();
    builder.Services.AddTransient<TodoHandler, TodoHandler>();
    builder.Services.AddDbContext<DataContext>(
        options =>
            options.UseInMemoryDatabase("Database"));

    // builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(ConfigurationBinder.GetConnectionString("ConnectionString")));
}