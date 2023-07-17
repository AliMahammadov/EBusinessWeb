using EBusinessCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace EBusinessEntity.Entities
{
    public class Comment:EntityBase
    {
        [MaxLength(15),MinLength(3)]
        public string Name { get; set; }
        [ EmailAddress]
        public string Email{ get; set; }
        [ MaxLength(450)]
        public string Comments { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
