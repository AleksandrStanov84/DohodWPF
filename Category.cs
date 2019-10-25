using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DochodRaschod
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString() { return Name; }
    }

    class Dochot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
        public DateTime Data { get; set; }
        public Category category { get; set; }
        public int CategoryId { get; set; }
    }

    class Raschod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Sum { get; set; }
        public DateTime Data { get; set; }
        public Category category{ get; set; }
        public int CategoryId { get; set; }
    }

    class UserContext : DbContext
    {
        public UserContext() : base("DbConnection") { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Dochot> Dochot { get; set; }
        public DbSet<Raschod> Raschod { get; set; }
    }
}
