﻿using Booking.Domain.Interfaces;
using Booking.Repository.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> GetByIdAsync(object id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
        public IQueryable<T> Query() => _dbSet.AsQueryable();
        public async Task<IEnumerable<T>> SearchAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }
        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => _context.Set<T>().AnyAsync(predicate);
    }
}
