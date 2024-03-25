using MediatR;

namespace DevFreela.Application.Commands.UpdateTasks
{
    public class UpdateTasksCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
