using CRUDTasks.Core.Entities;
using Xunit;

namespace CRUDTasks.UnitTests.Core.Entities
{
    public class TasksTests
    {
        [Fact]
        public void TestIfTasksStartWorks()
        {
            var tasks = new Tasks("Título de teste", "Nome De Teste", System.DateTime.Now);

            Assert.NotNull(tasks.Title);
            Assert.False(tasks.Title.GetType() == typeof(string));

            Assert.NotNull(tasks.Description);
            Assert.False(tasks.Description.GetType() == typeof(string));
        }
    }
}
