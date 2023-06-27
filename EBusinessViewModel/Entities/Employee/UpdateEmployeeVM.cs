using EBusinessEntity.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace EBusinessViewModel.Entities.Employee
{
    public class UpdateEmployeeVM
    {
        [Required, MaxLength(25), MinLength(3)]
        public string Name { get; set; }
        [Required, MaxLength(40), MinLength(3)]
        public string Surname { get; set; }
        [Required]
        public IFormFile Image { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public int? PositionId { get; set; }
        public Position? Position { get; set; }
    }
}
