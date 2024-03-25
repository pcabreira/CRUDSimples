using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CRUDTasks.Core.Entities;

namespace CRUDTasks.Infrastructure.Persistence.Configurations
{
    public class TasksConfigurations : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
