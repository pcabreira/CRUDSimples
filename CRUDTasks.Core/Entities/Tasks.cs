using System;
using System.Collections.Generic;
using System.Drawing;

namespace CRUDTasks.Core.Entities
{
    public class Tasks : BaseEntity
    {
        public Tasks(string title, string description, DateTime createdAt)
        {
            Title = title;
            Description = description;
            CreatedAt = createdAt;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
