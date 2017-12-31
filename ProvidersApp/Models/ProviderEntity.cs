using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvidersApp.Models
{
    public class ProviderContext : DbContext
    {
        public ProviderContext(DbContextOptions<ProviderContext> options)
            : base(options)
        { }

        public DbSet<ProviderEntity> Providers { get; set; }
    }

    public class ProviderEntity
    {
        public string ID { get; set; }
        public string Provider { get; set; }
    }
}
