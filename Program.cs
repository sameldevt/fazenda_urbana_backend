using AutoMapper;
using Data;
using DtoMapping;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;
using System.Text.Json.Serialization;
using Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

Logger.Initialize();

// Recupera e registra a string de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Logger.LogInformation($"Connection String: {connectionString}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IMensagemContatoRepository, MensagemContatoRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IMensagemContatoService, MensagemContatoService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Fazenda Urbana VerdeViva", Version = "v1" });
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.KeepAliveTimeout = TimeSpan.FromDays(365);
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fazenda Urbana VerdeViva v1"));
}

app.UseCors("PermitirTodos");

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Chama o Logger para registrar que a aplicação está sendo executada
Logger.LogInformation("Aplicação iniciada");

app.Run();
