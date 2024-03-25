using CRUDTasks.Core.Entities;
using CRUDTasks.Core.Repositories;
using CRUDTasks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriteriosAptas.Infrastructure.Persistence.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly TasksDbContext _dbContext;

        public TasksRepository(TasksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task AddAsync(Tasks task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Tasks> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var result = await _dbContext.Tasks.FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                _dbContext.Tasks.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
