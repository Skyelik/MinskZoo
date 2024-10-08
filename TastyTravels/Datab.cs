using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace TastyTravels
{
    internal class Datab : DbContext
    {
        public Datab() : base("DBConnection") { }
    

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AnimalInfo> AnimalInfo { get; set; }
        public DbSet<AnimalImg> AnimalImg { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Services> Services { get; set; }



    }
}

