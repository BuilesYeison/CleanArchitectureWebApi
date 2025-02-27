using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class FooRepository : IFooRepository
    {
        private readonly ApplicationDbContext _context;

        public FooRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Foo>,int)> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Foos.AsQueryable();
            var totalRecords = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return (items, totalRecords);
        }
    }
}
