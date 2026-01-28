using ViaCEP_Test.Interfaces;
using ViaCEP_Test.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Registra CepService como typed HttpClient com BaseAddress configurada
builder.Services.AddHttpClient<ICepService, CepService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(5);
    client.BaseAddress = new Uri("https://viacep.com.br/");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
