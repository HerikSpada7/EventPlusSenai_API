using EventPlus_API.Interfaces;
using EventPlus_API.Repositories;
using EventPlus_API.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a coleção de serviços da aplicação (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as opções do serializador JSON padrão (System.Text.Json)
    {
        // Configuração para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configuração para evitar referência circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<EventosContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITiposEventosRepository, TiposEventosRepository>();
builder.Services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();
builder.Services.AddScoped<IComentariosEventosRepository, ComentariosEventosRepository>();
builder.Services.AddScoped<IEventosRepository, EventosRepository>();
builder.Services.AddScoped<IPresencasRepository, PresencasRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuariosRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();