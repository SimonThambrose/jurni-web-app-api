using jurni_web_app_api;
using jurni_web_app_api.Repositories;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// UNCOMMENT LINES APPROPRIATE TO DESIRED DATABASE TYPE
// When using SSH tunneling to connect to a remote database
var connectionString = builder.Configuration.GetConnectionString("JurniWebAppApiDb");
builder.Services.AddDbContext<JurniWebAppApiDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// When using a local database
// var connectionString = builder.Configuration.GetConnectionString("JurniWebAppApiDb_local");
// builder.Services.AddDbContext<JurniWebAppDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IContactRequestRepository, ContactRequestRepository>();
builder.Services.AddTransient<IPlanRepository, PlanRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
} else if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<LikeHub>("/likeHub");
});

app.MapControllers();

app.Run();