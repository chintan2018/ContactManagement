using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ContactModel.POCOClasses;

namespace ContactModel
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=ContactDB")
        {

        }

        public DbSet<Contact> contacts { get; set; }
        
    }
}
