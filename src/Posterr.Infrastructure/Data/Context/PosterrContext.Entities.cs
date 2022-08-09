using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Posterr.Infrastructure.Data.Context
{
    public partial class PosterrContext : DbContext
    {
        public void CreateDataBaseTables(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entity.Post>().ToTable("posts");
            modelBuilder.Entity<Domain.Entity.User>().ToTable("users");
        }
    }
}
