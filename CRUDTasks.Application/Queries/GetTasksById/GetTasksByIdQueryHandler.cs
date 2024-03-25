using CRUDTasks.Application.ViewModels;
using CRUDTasks.Core.Repositories;
using DevFreela.Application.Queries.GetProjectById;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetTasksById
{
    public class GetTasksByIdQueryHandler : IRequestHandler<GetTasksByIdQuery, TasksViewModel>
    {
        private readonly ITasksRepository _tasksRepository;
        public GetTasksByIdQueryHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<TasksViewModel> Handle(GetTasksByIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _tasksRepository.GetByIdAsync(request.Id);

            if (tasks == null) return null;

            var tasksViewModel = new TasksViewModel(
                tasks.Id,
                tasks.Title,
                tasks.Description,
                tasks.CreatedAt
                );

            return tasksViewModel;
        }
    }
}
