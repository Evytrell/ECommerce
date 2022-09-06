using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext (DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        public DbSet<ECommerce.Models.Seller> Seller { get; set; } = default!;

        public DbSet<ECommerce.Models.Buyer>? Buyer { get; set; }
    }
}
