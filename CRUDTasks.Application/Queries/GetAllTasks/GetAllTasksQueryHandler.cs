using CRUDTasks.Application.Queries.GetAllTasks;
using CRUDTasks.Application.ViewModels;
using CRUDTasks.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDTasks.Application.Queries.GetAllCriterios
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TasksViewModel>>
    {
        private readonly ITasksRepository _criterioRepository;
        public GetAllTasksQueryHandler(ITasksRepository criterioRepository)
        {
            _criterioRepository = criterioRepository;
        }

        public async Task<List<TasksViewModel>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var criterios = await _criterioRepository.GetAllAsync();

            var criterioViewModel = criterios
                .Select(p => new TasksViewModel(p.Id, p.Title, p.Description, p.CreatedAt))
                .ToList();

            return criterioViewModel;
        }
    }
}
