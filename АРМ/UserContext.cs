using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace АРМ
{
    class UserContext:DbContext
    {
        public UserContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Categor> Categors { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Losses> Losses { get; set; }
        public DbSet<Publication> Publication { get; set; }

    }
}
