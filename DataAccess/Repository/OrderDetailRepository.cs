using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void Delete(int id) => OrderDetailDAO.Instance.Delete(id);

        public void Delete(int OrderID, int ProductID) => OrderDetailDAO.Instance.Delete(OrderID, ProductID);

        public OrderDetail Get(int id) => OrderDetailDAO.Instance.Get(id);

        public OrderDetail Get(int OrderID, int ProductID) => OrderDetailDAO.Instance.Get(OrderID, ProductID);

        public IEnumerable<OrderDetail> GetAll() => OrderDetailDAO.Instance.GetAll();

        public void Insert(OrderDetail orderDetail) => OrderDetailDAO.Instance.Insert(orderDetail);

        public void Update(OrderDetail orderDetail) => OrderDetailDAO.Instance.Update(orderDetail);
    }
}
