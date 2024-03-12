using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        public static readonly object instanceLock = new object();
       // private OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                return instance;
            }
        }
        public IEnumerable<OrderDetail> GetAll()
        {
            IEnumerable<OrderDetail> orders= new List<OrderDetail>();
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                orders = context.OrderDetails;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public OrderDetail Get(int id)
        {
            OrderDetail order;
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                order= context.OrderDetails.Where(x=> x.ProductId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public void Delete(int id){
            {
                try
                {
                     SaleManagementContext context = new SaleManagementContext();
                    OrderDetail order = Get(id);
                    if (order == null) throw new Exception("OrderDetail id not exist!!!");
                    context.OrderDetails.Remove(order);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Update(OrderDetail orderDetail)
        {
            {
                try
                {
                     SaleManagementContext context = new SaleManagementContext();
                    context.OrderDetails.Update(orderDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public void Insert(OrderDetail orderDetail)
        {
            {
                try
                {
                     SaleManagementContext context = new SaleManagementContext();
                    context.OrderDetails.Add(orderDetail);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public OrderDetail Get(int OrderID, int ProductID)
        {
            OrderDetail order;
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                order = context.OrderDetails.Where(x => x.ProductId == ProductID && x.OrderId== OrderID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public void Delete(int OrderID, int ProductID)
        {
            {
                try
                {
                    SaleManagementContext context = new SaleManagementContext();
                    OrderDetail order = Get(OrderID, ProductID);
                    if (order == null) throw new Exception("OrderDetail id not exist!!!");
                    context.OrderDetails.Remove(order);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

