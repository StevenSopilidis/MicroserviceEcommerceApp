
using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdResult(Product Product);
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQuery> logger) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", query);
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken) 
                ?? throw new ProductNotFoundException();
            return new GetProductByIdResult(product);
        }
    }
}