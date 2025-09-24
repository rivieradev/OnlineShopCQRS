using MediatR;
using OnlineShopCQRS.Domain;

namespace OnlineShopCQRS.Application.Products.Queries;

public record GetProductByIdQuery(Guid Id) : IRequest<Product?>;
