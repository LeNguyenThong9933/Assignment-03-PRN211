using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        public static readonly object instanceLock = new object();
        //private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                return instance;
            }
        }
        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> products;
            try
            {
                SaleManagementContext context = new SaleManagementContext();
                products= context.Products;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }
        public Product Get(int id)
        {
            Product product;
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                product= context.Products.Where(x=> x.ProductId == id).FirstOrDefault();
                //product.Category= context.Categories.Where(x=> x.CategoryId == product.CategoryId).FirstOrDefault();    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }
        public void Delete(int id)
        {
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                Product product= Get(id);
                if (product == null) throw new Exception("product id not exist!!!");
                context.Products.Remove(product);
                context.SaveChanges();  
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Product product)
        {
            try
            {

                SaleManagementContext context = new SaleManagementContext();
                context.Products.Update(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(Product product)
        {
            try
            {
                 SaleManagementContext context = new SaleManagementContext();
                context.Products.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

