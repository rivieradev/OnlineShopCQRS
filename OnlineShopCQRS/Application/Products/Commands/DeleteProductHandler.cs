using MediatR;
using OnlineShopCQRS.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopCQRS.Application.Products.Commands;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly AppDbContext _context;

    public DeleteProductHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null) return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
