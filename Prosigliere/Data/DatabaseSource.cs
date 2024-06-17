using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Prosigliere.Entities;
using System.Threading.Tasks;

namespace Prosigliere.Data
{
    public class DatabaseSource : DbContext, IDatabaseSource
    {
        private const string Schema = "Prosigliere";
        public DatabaseSource(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Comment> Comment { get; set; }

        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return Database.BeginTransactionAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(Schema);
            builder.ApplyConfigurationsFromAssembly(typeof(DatabaseSource).Assembly);
        }
    }
}
