using Feedback.Web.Data;
using Feedback.Web.Interfaces.DomainServices;
using Feedback.Web.Services;
using Feedback.Web.Types;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data;
using Restaurant.Infrastructure.Interfaces;

const string policyName = "AllowOrigin";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


//DBContext
builder.Services.AddDbContext<ReviewContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

//Build services
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IOrderService, OrderService>();
 


//Build repositories
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
// JWT Configuration

//graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<QueryType>();
          
var app = builder.Build();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(policyName);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Redirect root URL to Swagger UI
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
    }
    else
    {
        await next();
    }
});

app.MapGraphQL("/graphql");


app.Run();

public partial class Program { }