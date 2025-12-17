/* public class ProductService
{
    private readonly IMongoRepo<Product> _productRepo;

    public ProductService(IMongoRepo<Product> productRepo)
    {
        _productRepo = productRepo;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _productRepo.GetAllAsync();
    }

    public async Task AddProductAsync(Product product)
    {
        await _productRepo.AddAsync(product);
    }
} */

using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class ProductService
{
    private readonly IMongoCollection<Product> _productCollection;

    public ProductService(IOptions<MongoDBSettings> mongoSettings, IMongoClient mongoClient)
    {
        var settings = mongoSettings.Value;
        var database = mongoClient.GetDatabase(settings.DatabaseName);

        // Explicitly specify the collection name to avoid default conventions
        _productCollection = database.GetCollection<Product>(settings.CollectionName); // uses "products"
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        // Fetch all documents (products) from the collection
        return await _productCollection.Find(_ => true).ToListAsync();
    }

    public async Task AddProductAsync(Product product)
    {
        // Insert a new product document into the collection
        await _productCollection.InsertOneAsync(product);
    }
}