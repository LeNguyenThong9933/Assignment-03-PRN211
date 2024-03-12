using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repository
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAll();
        public Order Get(int id);
        public void Delete(int id);
        public void Update(Order orderr);
        public void Insert(Order orderr);
    }
}
