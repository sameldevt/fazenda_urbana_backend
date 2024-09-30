using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositórios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IFaleConoscoRepository, FaleConoscoRepository>();


// Registro de serviços com as interfaces correspondentes
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IFaleConoscoService, FaleConoscoService>();
builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IFaleConoscoService, FaleConoscoService>();

// Adiciona serviços CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", builder =>
    {
        builder.AllowAnyOrigin() // Permite qualquer origem (não recomendado em produção)
               .AllowAnyMethod() // Permite todos os métodos HTTP (GET, POST, etc.)
               .AllowAnyHeader(); // Permite todos os headers
    });
});

// Configuração do JSON para preservar referências circulares
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

// Configuração do Swagger para documentação da API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Fazenda Urbana VerdeViva", Version = "v1" });
});


var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Fazenda Urbana VerdeViva"));
}

app.UseCors("PermitirTodos"); // Nome da política que deseja aplicar

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
