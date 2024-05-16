using Microsoft.EntityFrameworkCore;
using Quick.DataAccess.Data;
using Quick.DataAccess.Repository.IRepository;
using Quick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Quick.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


       

        public void Update(Product obj)
        {
            var objFromDb = _db.Product.FirstOrDefault(u => u.ProductId == obj.ProductId);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.ProductId = obj.ProductId;
                objFromDb.Price = obj.Price;
                objFromDb.Description = obj.Description;
                objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                    
                }
                
            }
        }
    }
}
