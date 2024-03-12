using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
namespace DataAccess.Repository
{
    public interface IOrderDetailRepository
    {
        public IEnumerable<OrderDetail> GetAll();
        public OrderDetail Get(int id);
        public void Delete(int id);
        public void Update(OrderDetail orderDetail);
        public void Insert(OrderDetail orderDetail);
        public OrderDetail Get(int OrderID, int ProductID);
        public void Delete(int OrderID, int ProductID);
    }
}
