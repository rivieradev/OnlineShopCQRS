using MediatR;

namespace OnlineShopCQRS.Application.Products.Commands;

public record CreateProductCommand(string Name, decimal Price) : IRequest<Guid>;