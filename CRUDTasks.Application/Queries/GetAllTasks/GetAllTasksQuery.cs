using CRUDTasks.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CRUDTasks.Application.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<List<TasksViewModel>>
    {

    }
}
