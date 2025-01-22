using API_per_il_monitoraggio_delle_api_mellifere.Data.Seeding;
using API_per_il_monitoraggio_delle_api_mellifere.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurazione dei servizi
builder.Services.AddControllers();
builder.Services.AddDbContext<ContestoApiario>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnessionePredefinita")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Monitoraggio Api", Version = "v1" });
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ContestoApiario>();
    DbInitializer.Initialize(context);
}

// Configurazione del pipeline delle richieste HTTP
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Monitoraggio Api v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
