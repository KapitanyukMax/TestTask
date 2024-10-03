using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class IncidentsRepository : IIncidentsRepository
    {
        internal TestTaskDbContext context;
        internal DbSet<Incident> dbSet;

        public IncidentsRepository(TestTaskDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Incident>();
        }

        public Task Save() => context.SaveChangesAsync();

        public async Task<IEnumerable<Incident>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Incident?> GetByName(object name)
        {
            return await dbSet.FindAsync(name);
        }

        public async Task Insert(Incident incident)
        {
            await dbSet.AddAsync(incident);
        }
    }
}
