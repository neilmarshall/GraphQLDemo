using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraphQLDemo.Interfaces.Models.Production;

namespace GraphQLDemo.Client.Tests
{
    [TestClass]
    public class GraphQLDemoClientFixtures
    {
        private static GraphQLDemoClient client;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            client = new GraphQLDemoClient("https://localhost:5001/graphql");
        }

        [TestMethod]
        public async Task GetBrandsFixture()
        {
            var actual = await client.GetBrands();

            var expected = new Brand[]
            {
                new Brand { Id = 1, BrandName = "Electra" },
                new Brand { Id = 2, BrandName = "Haro" },
                new Brand { Id = 3, BrandName = "Heller" },
                new Brand { Id = 4, BrandName = "Pure Cycles" },
                new Brand { Id = 5, BrandName = "Ritchey" },
                new Brand { Id = 6, BrandName = "Strider" },
                new Brand { Id = 7, BrandName = "Sun Bicycles" },
                new Brand { Id = 8, BrandName = "Surly" },
                new Brand { Id = 9, BrandName = "Trek" }
            };

            foreach (var (e, a) in expected.Zip(actual, (e, a) => (e, a)))
            {
                Assert.AreEqual(e.Id, a.Id);
                Assert.AreEqual(e.BrandName, a.BrandName);
            }
        }

        [DataTestMethod]
        [DataRow(1, "Electra")]
        [DataRow(99, null)]
        public async Task GetBrandFixture(int brandId, string expectedBrandName)
        {
            var actual = await client.GetBrand(brandId);

            Assert.AreEqual(expectedBrandName, actual?.BrandName);
        }
    }
}
