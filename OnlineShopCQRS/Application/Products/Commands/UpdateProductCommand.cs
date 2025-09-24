using MediatR;

namespace OnlineShopCQRS.Application.Products.Commands;

public record UpdateProductCommand(Guid Id, string Name, decimal Price) : IRequest<bool>;
