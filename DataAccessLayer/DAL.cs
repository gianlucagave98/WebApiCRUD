using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class DAL
    {
        static APIDBEntities DbContext;
        static DAL()
        {
            DbContext = new APIDBEntities();
        }
        public static List<Product> GetAllProducts()
        {
            return DbContext.Product.ToList();
        }
        public static Product GetProduct(int productId)
        {
            return DbContext.Product.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public static bool InsertProduct(Product productItem)
        {
            bool status;
            try
            {
                DbContext.Product.Add(productItem);
                DbContext.SaveChanges();
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool UpdateProduct(Product productItem)
        {
            bool status;
            try
            {
                Product prodItem = DbContext.Product.Where(p => p.ProductId == productItem.ProductId).FirstOrDefault();
                if (prodItem != null)
                {
                    prodItem.ProductName = productItem.ProductName;
                    prodItem.Quantity = productItem.Quantity;
                    prodItem.Price = productItem.Price;
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
        public static bool DeleteProduct(int id)
        {
            bool status;
            try
            {
                Product prodItem = DbContext.Product.Where(p => p.ProductId == id).FirstOrDefault();
                if(prodItem != null)
                {
                    DbContext.Product.Remove(prodItem);
                    DbContext.SaveChanges();
                }
                status = true;
            }
            catch (Exception)
            {
                status = false;
            }
            return status;
        }
    }
}
