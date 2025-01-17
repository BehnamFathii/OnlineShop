using OnlineShop.Store.Core.ApplicationServices.Framework.Commands;

namespace OnlineShop.Store.Core.ApplicationServices.Products.Commands;
public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, long>
{
    public CreateProductCommandHandler()
    {

    }

    public async Task<long> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Create and save Product
        return 0;
    }
}
