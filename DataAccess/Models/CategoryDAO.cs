using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccess.Models
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        public static readonly object instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                return instance;
            }
        }
        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = new List<Category>();
            try
            {
                using SaleManagementContext context = new SaleManagementContext();
                categories = context.Categories;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }
        public Category Get(int id)
        {
            Category category;
            try
            {
                using SaleManagementContext context = new SaleManagementContext();
                category= context.Categories.Where(x=> x.CategoryId == id).FirstOrDefault(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }
        public void Delete(int id)
        {
            try
            {
                using SaleManagementContext context = new SaleManagementContext();
                Category category = Get(id);
                if (category == null) throw new Exception("Category not exist!!!");
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Update(Category category)
        {
            try
            {
                using SaleManagementContext context = new SaleManagementContext();
                context.Categories.Update(category);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Insert(Category category)
        {
            try
            {
                using SaleManagementContext context = new SaleManagementContext();
                context.Categories.Add(category);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

