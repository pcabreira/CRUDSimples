using CRUDTasks.Application.Queries.GetAllCriterios;
using CRUDTasks.Application.Queries.GetAllTasks;
using CRUDTasks.Core.Entities;
using CRUDTasks.Core.Repositories;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CRUDTasks.UnitTests.Application.Queries
{
    public class GetAllTasksCommandHandlerTests
    {
        [Fact]
        public async Task ThreeTaskssExist_Executed_ReturnThreeTasksViewModels()
        {
            // Arrange
            var tasks = new List<Tasks>
            {
                new Tasks("Título Do Teste 1", "Título Do Teste 1", System.DateTime.Now),
                new Tasks("Título Do Teste 2", "Título Do Teste 1", System.DateTime.Now),
                new Tasks("Título Do Teste 3", "Título Do Teste 1", System.DateTime.Now)
            };

            var tasksRepositoryMock = new Mock<ITasksRepository>();
            tasksRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(tasks);

            var getAllTaskssQuery = new GetAllTasksQuery();
            var getAllTaskssQueryHandler = new GetAllTasksQueryHandler(tasksRepositoryMock.Object);

            // Act
            var tasksViewModelList = await getAllTaskssQueryHandler.Handle(getAllTaskssQuery, new CancellationToken());

            // Assert
            Assert.NotNull(tasksViewModelList);
            Assert.NotEmpty(tasksViewModelList);
            Assert.Equal(tasks.Count, tasksViewModelList.Count);

            tasksRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
