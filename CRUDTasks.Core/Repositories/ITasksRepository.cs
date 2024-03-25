using CRUDTasks.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDTasks.Core.Repositories
{
    public interface ITasksRepository
    {
        Task AddAsync(Tasks criterio);
        Task<List<Tasks>> GetAllAsync();
        Task<Tasks> GetByIdAsync(int id);
        Task SaveChangesAsync();
        Task RemoveAsync(int id);
    }
}
