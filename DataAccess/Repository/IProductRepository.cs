using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAll();
        public Product Get(int id);
        public void Delete(int id); 
        public void Update(Product product);    
        public void Insert(Product product);
    }
}
