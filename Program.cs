using _.VerdeViva.Data;
using _.VerdeViva.Services;
using _.VerdeViva.Data.Repositories.ClienteRepository;
using _.VerdeViva.Data.Repositories.DashboardRepository;
using _.VerdeViva.Data.Repositories.ProdutoRepository;
using _.VerdeViva.Data.Repositories.CategoriaRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona serviços ao contêiner
builder.Services.AddControllers();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped<LojaService>();
builder.Services.AddScoped<ProducaoService>();
builder.Services.AddScoped<DashboardService>();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
app.UseAuthorization();
app.MapControllers();


app.Run();