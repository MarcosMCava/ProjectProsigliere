using Microsoft.EntityFrameworkCore;
using Prosigliere.Entities;
using System.Collections.Generic;

namespace Prosigliere.Data
{
    public interface IDatabaseSource
    {
        DbSet<BlogPost> BlogPost { get; set; }
        DbSet<Comment> Comment { get; set; }
    }
}
