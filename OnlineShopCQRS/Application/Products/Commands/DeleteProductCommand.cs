using MediatR;

namespace OnlineShopCQRS.Application.Products.Commands;

public record DeleteProductCommand(Guid Id) : IRequest<bool>;
