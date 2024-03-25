using CRUDTasks.Application.Commands.CreateTasks;
using CRUDTasks.Core.Entities;
using CRUDTasks.Core.Repositories;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CRUDTasks.UnitTests.Application.Commands
{
    public class CreateTasksCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnTasksId()
        {
            // Arrange
            var tasksRepository = new Mock<ITasksRepository>();

            var createTasksCommand = new CreateTasksCommand
            {
                Title = "Título teste",
                Description = "Nome de Teste"
            };

            var createTasksCommandHandler = new CreateTasksCommandHandler(tasksRepository.Object);

            // Act
            var id = await createTasksCommandHandler.Handle(createTasksCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            tasksRepository.Verify(pr => pr.AddAsync(It.IsAny<Tasks>()), Times.Once);
        }
    }
}
