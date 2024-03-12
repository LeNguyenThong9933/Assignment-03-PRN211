using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void Delete(int id) => OrderDAO.Instance.Delete(id);

        public Order Get(int id) => OrderDAO.Instance.Get(id);

        public IEnumerable<Order> GetAll() => OrderDAO.Instance.GetAll();

        public void Insert(Order orderr) => OrderDAO.Instance.Insert(orderr);

        public void Update(Order orderr) => OrderDAO.Instance.Update(orderr);
    }
}
