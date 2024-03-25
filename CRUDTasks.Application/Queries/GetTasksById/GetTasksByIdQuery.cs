using CRUDTasks.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetTasksByIdQuery : IRequest<TasksViewModel>
    {
        public GetTasksByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
