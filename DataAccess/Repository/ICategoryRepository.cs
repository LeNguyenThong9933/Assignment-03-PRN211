using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repository
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetAll();
        public Category Get(int id);
        public void Delete(int id);
        public void Update(Category category);
        public void Insert(Category category);
    }
}
