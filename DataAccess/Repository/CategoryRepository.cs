using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public void Delete(int id) => CategoryDAO.Instance.Delete(id);

        public Category Get(int id) => CategoryDAO.Instance.Get(id);

        public IEnumerable<Category> GetAll() => CategoryDAO.Instance.GetAll();

        public void Insert(Category category) => CategoryDAO.Instance.Insert(category);

        public void Update(Category category) => CategoryDAO.Instance.Update(category);
    }
}
