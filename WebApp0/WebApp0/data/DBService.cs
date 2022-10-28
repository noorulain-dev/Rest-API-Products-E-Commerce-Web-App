using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp0.data
{
    public class DBService
    {
        private MongoClient client = new MongoClient("mongodb://localhost:27017");

        private IMongoDatabase database;
        private IMongoCollection<User> userCollection;
        private IMongoCollection<Product> productCollection;
        private IMongoCollection<Support> supportCollection;
        private IMongoCollection<Basket> basketCollection;

        public DBService()
        {
            database = client.GetDatabase("WebApp0");
            userCollection = database.GetCollection<User>("data");
            productCollection = database.GetCollection<Product>("data");
            supportCollection = database.GetCollection<Support>("data");
            basketCollection = database.GetCollection<Basket>("data");
        }

        public async Task<List<User>> GetUsers()
        {
            return await userCollection.Find<User>(
                e => e.Type == User.DBType
                ).ToListAsync();
        }

        public async void CreateUser(User user)
        {
            await userCollection.InsertOneAsync(user);
        }

        public async void DeleteUser(int userId)
        {
            await userCollection.DeleteOneAsync<User>(
                e => e.UserId == userId
                && e.Type == User.DBType
                );
        }

        public async Task<List<Product>> GetProducts()
        {
            return await productCollection.Find<Product>(
                e => e.Type == Product.DBType
                ).ToListAsync();
        }

        public async void CreateProduct(Product product)
        {
            await productCollection.InsertOneAsync(product);
        }

        public async void DeleteProduct(int productId)
        {
            await productCollection.DeleteOneAsync<Product>(
                e => e.ProductId == productId
                && e.Type == Product.DBType
            );
        }

        public async Task<List<Basket>> GetBaskets()
        {
            return await basketCollection.Find<Basket>(
                e => e.Type == Basket.DBType
                ).ToListAsync();
        }

        public async void CreateBasket(Basket basket)
        {
            await basketCollection.InsertOneAsync(basket);
        }

        public async void DeleteBasket(int basketId)
        {
            await basketCollection.DeleteOneAsync<Basket>(
                e => e.UserId == basketId
                && e.Type == Basket.DBType
            );
        }

        public async Task<List<Support>> GetSupports()
        {
            return await supportCollection.Find<Support>(
                e => e.Type == Support.DBType
                ).ToListAsync();
        }

        public async void CreateSupport(Support support)
        {
            await supportCollection.InsertOneAsync(support);
        }

        public async void DeleteSupport(int supportId)
        {
            await supportCollection.DeleteOneAsync<Support>(
                e => e.SupportId == supportId
                && e.Type == Support.DBType
            );
        }
    }
}
