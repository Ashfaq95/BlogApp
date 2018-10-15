using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBGEntity;

namespace UserBGRepository
{
    public class UserRepository
    {   
        private UserBGDBContext context = new UserBGDBContext();

        public List<User> GetAll() { return this.context.Users.ToList(); }

        public int Insert(User user) 
        { 
            this.context.Users.Add(user);
            return this.context.SaveChanges();
        }

        public User Get(int id) 
        {
            return this.context.Users.SingleOrDefault(p => p.Id == id);
        }

        public int Update(User user)
        {
            User userToUpdate = this.Get(user.Id);
            userToUpdate.Username = user.Username;
            userToUpdate.Password = user.Password;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            User userToUpdate = this.Get(id);
            this.context.Users.Remove(userToUpdate);
            return this.context.SaveChanges();
        }
        public bool Validate(User user)
        {
            if (user.Username == "Admin") { return false; }
            User validUser = this.context.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            return validUser !=null;
        }


    }
}
