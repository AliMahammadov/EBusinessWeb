using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace EBusinessEntity.Entities.User
{
    public class AppUser:IdentityUser
    {
        [MaxLength(15)]
        public string Name { get; set; }
        [MaxLength(25)]
        public string Surname { get; set; }
        public bool IsParsistance { get; set; }
    }
}
