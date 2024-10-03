using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccess.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        internal TestTaskDbContext context;
        internal DbSet<Contact> dbSet;

        public ContactsRepository(TestTaskDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<Contact>();
        }

        public Task Save() => context.SaveChangesAsync();

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Contact?> GetByEmail(object email)
        {
            return await dbSet.FindAsync(email);
        }

        public async Task Insert(Contact contact)
        {
            await dbSet.AddAsync(contact);
        }

        public Task Update(Contact contactToUpdate)
        {
            return Task.Run(() =>
            {
                var trackedEntity = context.ChangeTracker.Entries<Contact>()
                    .FirstOrDefault(e => e.Entity.Email == contactToUpdate.Email);

                if (trackedEntity != null)
                {
                    context.Entry(trackedEntity.Entity).State = EntityState.Detached;
                }

                context.Attach(contactToUpdate);
                context.Entry(contactToUpdate).State = EntityState.Modified;
            });
        }
    }
}