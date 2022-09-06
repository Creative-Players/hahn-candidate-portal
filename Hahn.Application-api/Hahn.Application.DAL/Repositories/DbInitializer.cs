using Hahn.Application.DAL.Data;
using Hahn.Application.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.Application.DAL.Repositories
{
    public class DbInitializer : IDbInitializer
    {
        private readonly HahnApplicationDbContext _db;
        public DbInitializer(HahnApplicationDbContext db)
        {
            _db = db;
        }
        public void Initialize()
        {
            try
            {

                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
