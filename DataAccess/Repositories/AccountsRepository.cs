using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        internal TestTaskDbContext context;
        internal DbSet<Account> dbSet;

        public AccountsRepository(TestTaskDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Account>();
        }

        public Task Save() => context.SaveChangesAsync();

        public async Task<IEnumerable<Account>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Account?> GetByName(object name)
        {
            return await dbSet.FindAsync(name);
        }

        public async Task Insert(Account account)
        {
            await dbSet.AddAsync(account);
        }
    }
}
