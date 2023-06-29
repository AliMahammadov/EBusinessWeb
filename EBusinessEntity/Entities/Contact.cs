using EBusinessCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBusinessEntity.Entities
{
    public class Contact:EntityBase
    {
        [Required,MaxLength(15)]
        public string Name { get; set; }
        [Required,MaxLength(25)]
        public string Subject { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,MaxLength(450)]
        public string Message { get; set; }
    }
}
