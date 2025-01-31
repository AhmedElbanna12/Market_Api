using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Market.Models
{
    public class MarketContext  : DbContext
    {

        public MarketContext(DbContextOptions<MarketContext>options) : base (options)
        {   
        }
        public DbSet<User> User { get; set; }

        public DbSet<Product> Product  { get; set; }






    }
}
