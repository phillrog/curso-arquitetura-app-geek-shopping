using GeekShopping.Email.MessageConsumer;
using GeekShopping.Email.Model.Context;
using GeekShopping.Email.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = builder.Configuration["Connection:Localhost"];

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<EmailContext>(options => options.UseSqlServer(connection));

var ctx = new DbContextOptionsBuilder<EmailContext>();
ctx.UseSqlServer<EmailContext>(connection);

builder.Services.AddSingleton(new EmailRepository(ctx.Options));
builder.Services.AddScoped<IEmailRepository, EmailRepository>();

builder.Services.AddHostedService<RabbitMQPaymentConsumer>();

builder.Services.AddControllers();


builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.Authority = "https://localhost:8475";
    options.Audience = "https://localhost:5000";

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,

        ValidateIssuer = false,
        ValidateAudience = false,

        ClockSkew = new System.TimeSpan(0, 0, 30)
    };
    options.Events = new JwtBearerEvents
    {
        OnChallenge = context =>
        {
            context.HandleResponse();
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";

            // Ensure we always have an error and error description.
            if (string.IsNullOrEmpty(context.Error))
                context.Error = "invalid_token";
            if (string.IsNullOrEmpty(context.ErrorDescription))
                context.ErrorDescription = "This request requires a valid JWT access token to be provided";

            // Add some extra context for expired tokens.
            if (context.AuthenticateFailure != null && context.AuthenticateFailure.GetType() == typeof(SecurityTokenExpiredException))
            {
                var authenticationException = context.AuthenticateFailure as SecurityTokenExpiredException;
                context.Response.Headers.Add("x-token-expired", authenticationException.Expires.ToString("o"));
                context.ErrorDescription = $"The token expired on {authenticationException.Expires.ToString("o")}";
            }

            return context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                error = context.Error,
                error_description = context.ErrorDescription
            }));
        },
        OnTokenValidated = context =>
        {
            return Task.CompletedTask;
        }
    };

    options.BackchannelHttpHandler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "geek_shopping");
    });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GeekShopping.Email", Version = "v1" });
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
