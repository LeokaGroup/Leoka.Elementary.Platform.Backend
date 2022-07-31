using Autofac;
using Autofac.Extensions.DependencyInjection;
using Leoka.Elementary.Platform.Backend.Core.Data;
using Leoka.Elementary.Platform.Core.Data;
using Leoka.Elementary.Platform.Core.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
    });

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(AutoFac.Init);

// Нужно для типа timestamp в Postgres.
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // app.UseExceptionHandler("Добавить описание ошибки.");
}

// else
// {
//     app.UseExceptionHandler();
// }

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseRouting();
app.UseCors("ApiCorsPolicy");

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Leoka.Elementary.Platform"));
app.Run();