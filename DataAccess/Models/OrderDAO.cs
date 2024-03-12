using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    internal class OrderDAO
    {
        private static OrderDAO instance = null;
        public static readonly object instanceLock = new object();
        private OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                return instance;
            }
        }
        public IEnumerable<Order> GetAll()
        {
            IEnumerable<Order> orders;
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                orders = context.Orders;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }
        public Order Get(int id)
        {
            Order order;
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                order = context.Orders.Where(x => x.OrderId == id).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }
        public void Delete(int id)
        {
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                Order order= Get(id);
                if (order == null) throw new Exception("Order id not exist!!!");
                context.Orders.Remove(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Order order)
        {
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                context.Orders.Update(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(Order order)
        {
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

