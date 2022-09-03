using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace VertexAssessmentApp.Models.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        public DbSet<UserDetails> Users { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries<BaseEntity>())
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.Id = Guid.NewGuid();
                        item.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        item.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
