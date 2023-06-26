using EBusinessCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBusinessEntity.Entities
{
    public class Position:EntityBase
    {
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public ICollection<Employee>?  Employees { get; set; }
    }
}
