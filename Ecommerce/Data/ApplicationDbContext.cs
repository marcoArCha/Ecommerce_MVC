using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data
{
    //Mainly configuration
    public class ApplicationDbContext : DbContext
    {
        //Pass connection string
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
