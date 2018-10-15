using BlogEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGRepository
{
    public class BlogRepository
    {
        private BlogDBContext context = new BlogDBContext();

        public List<Blog> GetAll()
        {
            return this.context.Blogs.ToList();
        }
        public int Insert(Blog blog)
        {
             this.context.Blogs.Add(blog);
            return this.context.SaveChanges();
        
        }
        public Blog Get(int id)
        {
            //var result = from p in this.context.People
            //             where p.Id == id
            //             select p;
            //List<Person> plist = result.ToList();
            //return plist[0];

            return this.context.Blogs.SingleOrDefault(p => p.Id == id);
        }

       

        public int Update(Blog blog)
        {
            Blog blogToUpdate = this.Get(blog.Id);
            blogToUpdate.Title = blog.Title;
            blogToUpdate.Image = blog.Image;
            blogToUpdate.Description = blog.Description;
            blogToUpdate.Date = blog.Date;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Blog blogToUpdate = this.Get(id);
            this.context.Blogs.Remove(blogToUpdate);
            return this.context.SaveChanges();
        }
    }
}
