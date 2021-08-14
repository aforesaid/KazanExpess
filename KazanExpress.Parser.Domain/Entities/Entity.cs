using System;
using System.ComponentModel.DataAnnotations;

namespace KazanExpress.Parser.Domain.Entities
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
        
        public DateTime Created { get; private set; } = DateTime.Now;
        public DateTime Updated { get; private set; } = DateTime.Now;
        public bool IsDeleted { get; private set; }

        public void SetUpdated()
        {
            Updated = DateTime.Now;
        }

        public void SetInactive()
        {
            IsDeleted = true;
        }
        
    }
}