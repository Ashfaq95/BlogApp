using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminEntity;

namespace AdminBGRepository
{
    public class AdminRepository
    {
        private AdminBGDBContext context = new AdminBGDBContext();

        public List<Admin> GetAll() { return this.context.Admins.ToList(); }

        public int Insert(Admin admin)
        {
            this.context.Admins.Add(admin);
            return this.context.SaveChanges();
        }

        public Admin Get(int id)
        {
            return this.context.Admins.SingleOrDefault(p => p.Id == id);
        }

        public int Update(Admin admin)
        {
            Admin adminToUpdate = this.Get(admin.Id);
            adminToUpdate.Username = admin.Username;
            adminToUpdate.Password = admin.Password;
            return this.context.SaveChanges();
        }

        public int Delete(int id)
        {
            Admin adminToUpdate = this.Get(id);
            this.context.Admins.Remove(adminToUpdate);
            return this.context.SaveChanges();
        }
        public bool Validate(Admin user)
        {
            Admin validUser = this.context.Admins.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
            return validUser != null;
        }

    }
}
