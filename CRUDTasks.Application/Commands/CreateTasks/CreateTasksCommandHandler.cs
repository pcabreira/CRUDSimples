using CRUDTasks.Core.Entities;
using CRUDTasks.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDTasks.Application.Commands.CreateTasks
{
    public class CreateTasksCommandHandler : IRequestHandler<CreateTasksCommand, int>
    {
        private readonly ITasksRepository _criterioRepository;
        public CreateTasksCommandHandler(ITasksRepository criterioRepository)
        {
            _criterioRepository = criterioRepository;
        }

        public async Task<int> Handle(CreateTasksCommand request, CancellationToken cancellationToken)
        {
            var description = new Tasks(
                request.Title,
                request.Description,
                DateTime.Now
             );

            await _criterioRepository.AddAsync(description);

            return description.Id;
        }
    }
}
