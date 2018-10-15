using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminEntity;
using System.Data.Entity;

namespace AdminBGRepository
{
    public class AdminBGDBContext:DbContext 
    {
        public DbSet<Admin> Admins { get; set; } 
    }
}
