using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp0.Controllers;
using WebApp0.data;
using NUnit.Framework;

namespace WebApp0.UnitTests
{
    [TestFixture]
    class UnitTests
    {
        Task<List<Product>> prodList;
        Task<List<Basket>> basList;
        DBService db = new DBService();

        [Test]
        public void TestProduct()
        {
            ProductController pc1 = new ProductController(db);
            prodList = pc1.GetProducts();
            Assert.IsNotNull(prodList);

        }

        [Test]
        public void TestBasket()
        {
            List<int> prods = new List<int>();
            prods.Add(1);
            Basket newBas = new Basket
            {
                ProductId = prods,
                UserId = 1
            };

            BasketController pc2 = new BasketController(db);
            pc2.CreateBasket(newBas);
            basList = pc2.GetBasket();
            Assert.IsNotNull(basList);
        }

        [Test]
        public void TestUser()
        {
            Task<List<User>> userList;
            User user = new User
            {
                Name = "john",
                Email = "johnappleseed@apple.com",
                UserId = 1
            };

            UserController uc1 = new UserController(db);
            uc1.CreateUser(user);
            userList = uc1.GetUsers();
            Assert.IsNotNull(userList);
        }

        [Test]
        public void TestSupport()
        {
            Task<List<Support>> supList;
            Support sup = new Support
            {
                SupportId = 1,
                Message = "I want to leave a bigger tip"
            };

            SupportController sc1 = new SupportController(db);
            sc1.CreateSupport(sup);
            supList = sc1.GetSupport();
            Assert.IsNotNull(supList);
        }

    }
}
