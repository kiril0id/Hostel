
using System.Data.Entity;


namespace Hostel
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Сlients { get; set; }

        public ApplicationContext() : base("DefaultConnection")
        {

        }
        
    }
}
    