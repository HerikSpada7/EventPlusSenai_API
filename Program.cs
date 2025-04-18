using System.Reflection;
using Azure;
using Azure.AI.ContentSafety;
using EventPlus_API.Contexts;
using EventPlus_API.Interfaces;
using EventPlus_API.Repositories;
using EventPlus_API.Repositories.webapi.event_.Repositories;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//Configura��o do Azure Content Safety
var endpoint = builder.Configuration["AzureContentSafety:Endpoint"];
var apiKey = builder.Configuration["AzureContentSafety:ApiKey"];

if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
{
    throw new InvalidOperationException("Azure Content Safety: Endpoint ou API Key n�o foram configurados");
}

var client = new ContentSafetyClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
builder.Services.AddSingleton(client);




builder.Services // Acessa a cole��o de servi�os da aplica��o (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as op��es do serializador JSON padr�o (System.Text.Json)
    {
        // Configura��o para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configura��o para evitar refer�ncia circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<EventosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Adicionar o  e a interface ao container de inje��o de depend�ncia
builder.Services.AddScoped<ITiposEventosRepository, TiposEventosRepository>();
builder.Services.AddScoped<ITiposUsuariosRepository, TiposUsuariosRepository>();
builder.Services.AddScoped<IComentariosEventosRepository, ComentariosEventosRepository>();
builder.Services.AddScoped<IEventosRepository, EventosRepository>();
builder.Services.AddScoped<IPresencasRepository, PresencasRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuariosRepository>();

//Adicionar o servi�o de Controllers
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventos-chave-autenticacao-webapi-dev")),

        ClockSkew = TimeSpan.FromMinutes(5),

        ValidIssuer = "EventPlusAPI",

        ValidAudience = "EventPlusAPI"
    };
});



builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "Aplica�ao para gerenciamento de filmes e Generos",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Herik Spada",
            Url = new Uri("https://github.com/HerikSpada7/EventPlusSenai_API")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autentica�ao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

//Adiciona o Cors(pol�tica criada)
app.UseCors("CorsPolicy");

//Adicionar o mapeamento dos controllers
app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
