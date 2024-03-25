using CRUDTasks.Core.Entities;
using CRUDTasks.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteTasks
{
    public class DeleteTasksCommandHandler : IRequestHandler<DeleteTasksCommand, Unit>
    {
        private readonly ITasksRepository _tasksRepository;
        public DeleteTasksCommandHandler(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task<Unit> Handle(DeleteTasksCommand request, CancellationToken cancellationToken)
        {
            await _tasksRepository.RemoveAsync(request.Id);
            return Unit.Value;
        }
    }
}
