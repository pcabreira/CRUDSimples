using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevFreela.Application.Commands.DeleteTasks
{
    public class DeleteTasksCommand : IRequest<Unit>
    {
        public DeleteTasksCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
