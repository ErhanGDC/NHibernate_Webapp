using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL
{
    public class DatabaseModule : DbContext
    {
        public DbSet<ScientistEntity> Scientists { get; set; }
        public DbSet<Invention> Inventions { get; set; }
    }
    public class ScientistEntity
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }

        //Foreign key for Standard
        public ICollection<Invention> Invention { get; set; }
    }
    public class Invention
    {
        public int InventionID { get; set; }
        public string Description { get; set; }

        //Foreign key for Standard
        public int? ScientistID { get; set; }
        public virtual ScientistEntity ScientistEntity { get; set; }


    }
}
