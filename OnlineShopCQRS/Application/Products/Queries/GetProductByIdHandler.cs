using MediatR;
using OnlineShopCQRS.Infrastructure;
using OnlineShopCQRS.Domain;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopCQRS.Application.Products.Queries;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product?>
{
    private readonly AppDbContext _context;

    public GetProductByIdHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
    }
}
