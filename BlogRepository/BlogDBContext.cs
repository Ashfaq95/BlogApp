using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogEntity;
using System.Data.Entity;


namespace BlogRepository
{
    public class BlogDBContext: DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
    }
}
