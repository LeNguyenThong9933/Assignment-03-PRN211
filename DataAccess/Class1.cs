using DataAccess.Models;
using DataAccess.Repository;
namespace DataAccess
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            IProductRepository productRepository = new ProductRepository();
            var product = productRepository.GetAll().ToList();
            foreach(var item in product)
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}