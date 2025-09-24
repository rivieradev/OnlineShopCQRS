using MediatR;
using OnlineShopCQRS.Domain;
using OnlineShopCQRS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopCQRS.Application.Products.Queries;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly AppDbContext _context;

    public GetAllProductsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.ToListAsync(cancellationToken);
    }
}