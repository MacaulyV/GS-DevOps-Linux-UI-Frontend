using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do HttpClient para acessar a API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7049/api/"); // URL base da sua API
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Registrar os reposit�rios e associar �s suas interfaces
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVeiculoCombustaoRepository, VeiculoCombustaoRepository>();
builder.Services.AddScoped<IVeiculoEletricoRepository, VeiculoEletricoRepository>();

// Configura��o para usar Controllers e Views
builder.Services.AddControllersWithViews();

// Adicionar suporte a sess�o
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Adicionar suporte a sess�o
app.UseSession();

// Configura��o das rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
