using Microsoft.EntityFrameworkCore;
using MediatR;
using OnlineShopCQRS.Application.Products.Commands;
using OnlineShopCQRS.Application.Products.Queries;
using OnlineShopCQRS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add EF Core InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("OnlineShopDb"));

// Add MediatR
builder.Services.AddMediatR(typeof(CreateProductCommand).Assembly);

builder.Services.AddControllers();

var app = builder.Build();

app.MapPost("/products", async (CreateProductCommand command, IMediator mediator) =>
{
    var productId = await mediator.Send(command);
    return Results.Created($"/products/{productId}", productId);
});

app.MapGet("/products", async (IMediator mediator) =>
{
    var products = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(products);
});

app.Run();