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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(Category obj)
        {
            _db.Category.Update(obj);
        }

        
    }
}
