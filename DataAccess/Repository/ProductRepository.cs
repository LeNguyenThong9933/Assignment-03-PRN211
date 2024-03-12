using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void Delete(int id) => ProductDAO.Instance.Delete(id);

        public Product Get(int id) => ProductDAO.Instance.Get(id);

        public IEnumerable<Product> GetAll() => ProductDAO.Instance.GetAll();

        public void Insert(Product product) => ProductDAO.Instance.Insert(product);

        public void Update(Product product) => ProductDAO.Instance.Update(product);
    }
}
