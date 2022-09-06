using Hahn.Application.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.DAL.Data
{
    public class HahnApplicationDbContext : DbContext
    {
        public HahnApplicationDbContext(DbContextOptions<HahnApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobOption> JobOptions { get; set; }
    }
}
