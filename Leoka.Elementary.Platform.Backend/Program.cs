using Autofac;
using Autofac.Extensions.DependencyInjection;
using Leoka.Elementary.Platform.Access.IdentityServer;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder();
var configuration = builder.Configuration;

builder.Services.AddControllers().AddControllersAsServices();
builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", b =>
{
    b.WithOrigins(configuration.GetSection("CorsUrls:Urls").Get<string[]>())
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
}));

#region Для прода.

// builder.Services.AddDbContext<PostgreDbContext>(options =>
//     options.UseNpgsql(configuration.GetConnectionString("NpgConfigurationConnection")));

#endregion

#region Для теста.

builder.Services.AddDbContext<PostgreDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("NpgTestSqlConnection") ?? string.Empty));

#endregion

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Leoka.Elementary.Platform" }); });

builder.WebHost.UseKestrel().UseContentRoot(Directory.GetCurrentDirectory()).UseUrls("http://*:9991");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "http://localhost:9991";
        // options.Authority = "http://localhost:4200";
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // ValidateIssuer = true,
            // ValidIssuer = AuthOptions.ISSUER,
            // ValidateAudience = true,
            ValidateAudience = false,
            // ValidAudience = AuthOptions.AUDIENCE,
            // ValidateLifetime = true,
            // IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            // ValidateIssuerSigningKey = true
        };
        // options.Authority = "http://localhost:4200";
        // options.Audience = "leoka-elementary-web-api";
    });
// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(AutoFac.Init);

// Нужно для типа timestamp в Postgres.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Добавляем IdentityServer4.
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(Configuration.ApiScopes)
    .AddInMemoryClients(Configuration.Clients);
// .AddInMemoryApiResources(Configuration.ApiResources)
// .AddInMemoryIdentityResources(Configuration.IdentityResources)
// .AddInMemoryApiScopes(Configuration.ApiScopes)
// .AddInMemoryClients(Configuration.Clients)
// .AddDeveloperSigningCredential();

// Для доступа к HttpContext из других модулей.
// builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//TODO: вынести лучше это в мидлварю!
app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["token"];

    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", "Bearer " + token);
    }

    await next();
});
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseCors("ApiCorsPolicy");
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leoka.Elementary.Platform"));
app.UseIdentityServer();
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});
app.Run();