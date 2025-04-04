using BlazorProva.Repositories;
using BlazorProva.Services;
using Microsoft.OpenApi.Models;
using System.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Configuração do Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BlazorProva API",
        Version = "v1",
        Description = "API para gerenciamento de produtos"
    });
});

// Configuração do PostgreSQL via Npgsql
builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Injeção de dependências
builder.Services.AddScoped<ICurriculoRepository, CurriculoRepository>();
builder.Services.AddScoped<CurriculoService, CurriculoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlazorProva API v1");
});

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

/*
 * 🔧 Como adicionar mais funcionalidades aqui:
 * - Adicionar outros serviços/repositórios da mesma forma
 * - Adicionar políticas de segurança/autenticação
 * - Configurar Cors se for usar com frontend separado
 */
