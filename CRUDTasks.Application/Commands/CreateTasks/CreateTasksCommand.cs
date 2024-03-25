using MediatR;
using System;

namespace CRUDTasks.Application.Commands.CreateTasks
{
    public class CreateTasksCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
