using PTR.TPFinal.Services.Profiles;
using PTR.TPFinal.WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

const string AllowAllPolicy = "AllowAll";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services
    .AddDatabase(builder.Configuration)
    .AddMongoDatabase(builder.Configuration)
    .AddRepositories()
    .AddValidators()
    .AddServices()
    .AddSwaggerWithJwt()
    .AddJwtAuthentication(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllPolicy, policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Discutir en clase
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AreaProfile>();
    cfg.AddProfile<ClientProfile>();
    cfg.AddProfile<EmployeeProfile>();
    cfg.AddProfile<ProductProfile>();
    cfg.AddProfile<ShoppingCartProfile>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PTR Web App v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
