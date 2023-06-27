using EBusinessCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBusinessEntity.Entities
{
    public class Employee:EntityBase
    {
        [MaxLength(25), MinLength(3)]
        public string Name { get; set; }
        [MaxLength(40), MinLength(3)]
        public string Surname { get; set; }
        public string ImgUrl { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public int? PositionId { get; set; }
        public Position? Positions { get; set; }
    }
}
