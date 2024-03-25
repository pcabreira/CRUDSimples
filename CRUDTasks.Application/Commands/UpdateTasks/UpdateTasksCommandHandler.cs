using CRUDTasks.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateTasks
{
    public class UpdateTasksCommandHandler : IRequestHandler<UpdateTasksCommand, Unit>
    {
        private readonly ITasksRepository _tasksRepository;
        public UpdateTasksCommandHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<Unit> Handle(UpdateTasksCommand request, CancellationToken cancellationToken)
        {
            var tasks = await _tasksRepository.GetByIdAsync(request.Id);

            tasks.Update(request.Title, request.Description);

            await _tasksRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
