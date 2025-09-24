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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Enable Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CREATE product
app.MapPost("/products", async (CreateProductCommand command, IMediator mediator) =>
{
    var productId = await mediator.Send(command);
    return Results.Created($"/products/{productId}", productId);
})
.WithName("CreateProduct")
.WithOpenApi();

// READ all products
app.MapGet("/products", async (IMediator mediator) =>
{
    var products = await mediator.Send(new GetAllProductsQuery());
    return Results.Ok(products);
})
.WithName("GetAllProducts")
.WithOpenApi();

// READ product by ID
app.MapGet("/products/{id:guid}", async (Guid id, IMediator mediator) =>
{
    var product = await mediator.Send(new GetProductByIdQuery(id));
    return product is not null ? Results.Ok(product) : Results.NotFound();
})
.WithName("GetProductById")
.WithOpenApi();

// UPDATE product
app.MapPut("/products/{id:guid}", async (Guid id, UpdateProductCommand command, IMediator mediator) =>
{
    if (id != command.Id)
        return Results.BadRequest("ID in URL does not match ID in body.");

    var success = await mediator.Send(command);
    return success ? Results.NoContent() : Results.NotFound();
})
.WithName("UpdateProduct")
.WithOpenApi();

// DELETE product
app.MapDelete("/products/{id:guid}", async (Guid id, IMediator mediator) =>
{
    var success = await mediator.Send(new DeleteProductCommand(id));
    return success ? Results.NoContent() : Results.NotFound();
})
.WithName("DeleteProduct")
.WithOpenApi();

app.Run();